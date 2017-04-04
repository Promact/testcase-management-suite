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
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.External;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;
using Promact.TestCaseManagement.Repository.GlobalRepository;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.TestCaseRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using Promact.TestCaseManagement.Utility.Services.AccessToken;
using Promact.TestCaseManagement.Utility.Services.HttpClient;
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
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TestCaseManagementDbContext>(options => options.UseSqlServer("Server=PR1C4R3Y2016;Database=TestCaseManagement;User id=sa;Password=Promact201617"));

            //register application services
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<ITestCaseRepository, TestCaseRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectUserMappingRepository, ProjectUserMappingRepository>();
            services.AddScoped<IGlobalRepository, GlobalRepository>();
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddTransient<IAccessTokenService, AccessTokenService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
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
                AuthenticationScheme = StringConstants.Cookies,
                AutomaticAuthenticate = true
            });

            if (env.IsProduction())
                app.UseExceptionHandler("/Home/Error");

            app.UsePromactAuthentication(new PromactAuthenticationOptions
            {
                Authority = StringConstants.OAuthUrl,
                ClientId = StringConstants.ClientId,
                ClientSecret = StringConstants.ClientSecret,
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

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TestCaseAC, TestCase>().ReverseMap();
                cfg.CreateMap<TestCaseInputAc, TestCaseInput>().ReverseMap();
                cfg.CreateMap<TestCaseStepsAC, TestCaseSteps>().ReverseMap();
                cfg.CreateMap<UserInfo, UserAC>().ReverseMap();
                cfg.CreateMap<DomainModel.Models.Project, ProjectAC>().ReverseMap();
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}