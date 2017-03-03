﻿using AutoMapper;
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
using Promact.TestCaseManagement.DomainModel.Models.TestCase;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;
using Promact.TestCaseManagement.Repository.DataRepository;
using Promact.TestCaseManagement.Repository.TestCaseRepository;
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
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TestCaseManagementDbContext>(options => options.UseSqlServer(Configuration[StringConstants.ConnectionString]));

            //register application services
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
            services.AddScoped<ITestCaseRepository, TestCaseRepository>();
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

            app.UseExceptionHandler("/Home/Error");

            app.UsePromactAuthentication(new PromactAuthenticationOptions
            {
                Authority = StringConstants.OAuthUrl,
                ClientId = StringConstants.ClientId,
                ClientSecret = StringConstants.ClientSecret,
                AllowedScopes = { Scopes.offline_access, Scopes.openid, Scopes.profile },
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
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}