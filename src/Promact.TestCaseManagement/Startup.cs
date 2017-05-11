using AutoMapper;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Promact.OAuth.Client.DomainModel;
using Promact.OAuth.Client.Middleware;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.Repository.GlobalRepository;
using Promact.TestCaseManagement.Repository.ModuleRepository;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.ScenarioRepository;
using Promact.TestCaseManagement.Repository.TestCaseRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using Promact.TestCaseManagement.Utility.Services.AccessToken;
using Promact.TestCaseManagement.Utility.Services.HttpClient;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddDbContext<TestCaseManagementDbContext>(options => options.UseSqlServer(Configuration["DefaultConnection"], b => b.MigrationsAssembly("Promact.TestCaseManagement.Web")));

            //register application services
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IScenarioRepository, ScenarioRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<ITestCaseRepository, TestCaseRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectUserMappingRepository, ProjectUserMappingRepository>();
            services.AddScoped<IGlobalRepository, GlobalRepository>();
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddTransient<IAccessTokenService, AccessTokenService>();
            services.AddScoped<IStringConstant, StringConstant>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            var stringConstant = serviceProvider.GetService<IStringConstant>();

            loggerFactory.AddConsole(LogLevel.Trace);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();

            string libPath = Path.GetFullPath(Path.Combine(env.WebRootPath, @"..\node_modules\"));
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(libPath),
                RequestPath = new PathString("/node_modules")
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = stringConstant.Cookies,
                AutomaticAuthenticate = true
            });

            if (env.IsProduction())
                app.UseExceptionHandler("/Home/Error");

            app.UsePromactAuthentication(new PromactAuthenticationOptions
            {
                Authority = stringConstant.OAuthUrl,
                ClientId = stringConstant.ClientId,
                ClientSecret = stringConstant.ClientSecret,
                AllowedScopes = { Scopes.offline_access, Scopes.openid, Scopes.profile, Scopes.email, Scopes.project_read, Scopes.user_read },
                Event = new OpenIdConnectEvents
                {
                    OnRemoteFailure = context =>
                    {
                        context.Response.Redirect("/");
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }
                }
            });

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                // Matches requests that correspond to an existent controller/action pair
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Matches any other request that doesn't appear to have a filename extension (defined as 'having a dot in the last URI segment').
                // This means you'll correctly get 404s for /some/dir/non-existent-image.png instead of returning the SPA HTML.
                // However, it means requests like /customers/isaac.newton will *not* be mapped into the SPA, so if you need to accept
                // URIs like that you'll need to match all URIs, e.g.:
                //    routes.MapRoute("spa-fallback", "{*anything}", new { controller = "Home", action = "Index" });
                // (which of course will match /customers/isaac.png too, so in that case it would serve the PNG image at that URL if one is on disk,
                // or the SPA HTML if not).
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });
        }
    }
}