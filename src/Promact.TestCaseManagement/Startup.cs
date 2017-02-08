﻿using IdentityModel;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Promact.OAuth.Client.DomainModel;
using Promact.OAuth.Client.Middleware;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.Repository.DataRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
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
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile(StringConstants.Appsettings);
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TestCaseManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(StringConstants.TestCaseManagement)));

            //register application services
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Trace);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

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

            app.UsePromactAuthentication(new PromactAuthenticationOptions
            {
                Authority = StringConstants.OAuthUrl,
                ClientId = StringConstants.ClientId,
                ClientSecret = StringConstants.ClientSecret,
                AllowedScopes = { Scopes.offline_access, Scopes.openid, Scopes.profile },
                LogoutUrl = "/"
            });


            //app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            //{
            //    AuthenticationScheme = StringConstants.oidc,
            //    SignInScheme = StringConstants.Cookies,
            //    Authority = StringConstants.OAuthUrl,

            //    ClientId = StringConstants.ClientId,
            //    ClientSecret = StringConstants.ClientSecret,

            //    ResponseType = StringConstants.ResponseType,
            //    Scope = { StringConstants.OffLineAccess, StringConstants.OpenId, StringConstants.Profile },
            //    GetClaimsFromUserInfoEndpoint = true,
            //    SaveTokens = true,
            //    Events = new OpenIdConnectEvents
            //    {
            //        OnRemoteFailure = context =>
            //        {
            //            context.Response.Redirect("/");
            //            context.HandleResponse();
            //            return Task.FromResult(0);
            //        }
            //    },

            //    TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = JwtClaimTypes.Name,
            //        RoleClaimType = JwtClaimTypes.Role,
            //    }
            //});

            app.UseMvcWithDefaultRoute();
        }
    }
}