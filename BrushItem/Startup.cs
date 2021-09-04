using BrushItem.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Linq;
using BrushItem.Shared.Profiles;
using BrushItem.Respository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BrushItem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BrushDbContext>(options
               => options.UseMySql(Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(5, 7, 0))));
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                    .AllowCredentials();
            }));

            #region 验证授权
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5002";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromMinutes(3),
                    RequireExpirationTime = true
                };
                options.RequireHttpsMetadata = false;
            });
            #endregion
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Version = version,
                        Title = $"webapi {version}",
                        Description = $"Asp.NetCore Web API {version}"
                    });
                });

                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        AuthorizationCode = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri("https://localhost:5002/connect/authorize"),
                //            TokenUrl = new Uri("https://localhost:5002/connect/token"),
                //            Scopes = new Dictionary<string, string>
                //            {
                //                {"api1", "API Demo"}
                //            }
                //        }
                //    }
                //});
                ////这里的拦截器看下面的添加拦截器
                //c.OperationFilter<AuthorizeCheckOperationFilter>();
                //c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                //接入identityserver4


            });

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
                    {
                        c.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);
                    });
                    //    ////c.OAuthClientId("vclient");
                    //    ////c.OAuthAppName("Demo API - Swagger");
                    //    ////c.OAuthUsePkce();
                    //    //////c.EnableDeepLinking();
                    //    //c.OAuthClientId("vclient");
                    //    //////c.OAuthClientSecret("secret");
                    //    //c.OAuthAppName("test-app");
                    //    //c.OAuthScopeSeparator(" ");
                    //    //c.OAuthUsePkce();
                    //    //c.OAuth2RedirectUrl("http://127.0.0.1:8080/signin-oidc");
                    //    ////c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                });
            }
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = (SameSiteMode)(-1) });
            app.UseSerilogRequestLogging();
            app.UseCors("CorsPolicy");
            
            app.UseRouting();
            //身份验证
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });


        }
    }
}
