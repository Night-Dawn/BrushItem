// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using BrushItem.IdentityServer.Data;
using BrushItem.IdentityServer.Extensions;
using BrushItem.IdentityServer.Quickstart.Account;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Hosting;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace BrushItem.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "server=localhost;port=3306;user=root;password=root;database=brush;sslMode=None";
            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("https://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                //https://docs.microsoft.com/zh-cn/aspnet/core/security/samesite?view=aspnetcore-3.1&viewFallbackFrom=aspnetcore-3
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;

            });
            //services.ConfigureNonBreakingSameSiteCookies();
            // 数据库配置系统应用用户数据上下文
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseMySql(connectionString,
                         new MySqlServerVersion(new Version(5, 7, 0))));
            // 启用 Identity 服务 添加指定的用户和角色类型的默认标识系统配置
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            }).AddAspNetIdentity<ApplicationUser>()
            //添加配置数据（客户端 和 资源）
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseMySql(connectionString,
                         new MySqlServerVersion(new Version(5, 7, 0)), sql => sql.MigrationsAssembly(migrationsAssembly));
            })
             // 添加操作数据 (codes, tokens, consents)
             .AddOperationalStore(options =>
             {
                 options.ConfigureDbContext = b =>
                    b.UseMySql(connectionString,
                         new MySqlServerVersion(new Version(5, 7, 0)), sql => sql.MigrationsAssembly(migrationsAssembly));
                 // 自动清理 token ，可选
                 options.EnableTokenCleanup = true;
             });

            //.AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddInMemoryApiScopes(Config.ApiScopes)
            //.AddInMemoryClients(Config.Clients);
            //// not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
            //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            //    //.AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));
            //    .AddGitHub(options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //        options.ClientId = "1f1a15c7b9777c259469";
            //        options.ClientSecret = "dea39e79aecd997d323a3f7d2940b52beb5e6315";
            //        options.Scope.Add("user:email");
            //    });
            //services.AddAuthentication()
            //    .AddGitHub(options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //        options.ClientId = "09fb197ec0d2bddee451";
            //        options.ClientSecret = "5dccf2964824665e33e6ba7bc1f6a214f1510c48";
            //        options.Scope.Add("user:email");
            //    }); ;
            services.AddTransient<ITokenService, CustomTokenService>();
            services.AddTransient<IUserSession, CustomUserSession>();

        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //InitDatabase(app);
            //InitDatabaseUser(app);
            //InitDatabaseUser(app);
            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseCookiePolicy();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
        //private void InitDatabase(IApplicationBuilder app)
        //{
        //    // 从根作用域中创建一个子作用域，这个在之前的依赖注入生命周期中有说到
        //    using (var scope = app.ApplicationServices.CreateScope())
        //    {
        //        // 每个子作用域中有对应的容器，可以取到对应的对象
        //        scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        //        // 这里取到配置数据上下文
        //        var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        //        // 先判断Clients表中有数据没，没有就将内存中的数据存进去
        //        if (!configurationDbContext.Clients.Any())
        //        {
        //            // 遍历内存中配置的客户端数据，直接存进去即可
        //            foreach (var client in Config.Clients)
        //            {
        //                configurationDbContext.Clients.Add(client.ToEntity());
        //            }
        //            configurationDbContext.SaveChanges();
        //        }
        //        // 存ApiScopes
        //        if (!configurationDbContext.ApiScopes.Any())
        //        {
        //            foreach (var apiScope in Config.ApiScopes)
        //            {
        //                configurationDbContext.ApiScopes.Add(apiScope.ToEntity());
        //            }
        //            configurationDbContext.SaveChanges();
        //        }
        //        //存IdentityResources
        //        if (!configurationDbContext.IdentityResources.Any())
        //        {
        //            foreach (var identity in Config.IdentityResources)
        //            {
        //                configurationDbContext.IdentityResources.Add(identity.ToEntity());
        //            }
        //            configurationDbContext.SaveChanges();
        //        }
        //    }
        //}

        private void InitDatabaseUser(IApplicationBuilder app)
        {
            // 从根作用域中创建一个子作用域，这个在之前的依赖注入生命周期中有说到
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // 每个子作用域中有对应的容器，可以取到对应的对象
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                // 这里取到配置数据上下文
                var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                // 先判断Clients表中有数据没，没有就将内存中的数据存进去

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                foreach (var role in Config.Roles)
                {
                    var res = roleManager.CreateAsync(role).Result;
                    if (!res.Succeeded)
                    {
                        throw new Exception(res.Errors.First().Description);
                    }
                    Console.WriteLine($"{role.Name} created!");
                }

                // 创建用户
                foreach (var user in Config.Users)
                {
                    // 默认密码为 Test23
                    var res = userManager.CreateAsync(user, "Test_123").Result;
                    if (!res.Succeeded)
                    {
                        throw new Exception(res.Errors.First().Description);
                    }

                    // 创建用户的声明
                    var claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, user.LoginName),
                        new Claim(JwtClaimTypes.Email, user.Email)
                    };

                    res = userManager.AddClaimsAsync(user, claims).Result;
                    if (!res.Succeeded)
                    {
                        throw new Exception(res.Errors.First().Description);
                    }

                    // 创建用户的角色
                    var role = user.UserName == "night" ? "admin" : "user";
                    res = userManager.AddToRoleAsync(user, role).Result;
                    if (!res.Succeeded)
                    {
                        throw new Exception(res.Errors.First().Description);
                    }

                    Console.WriteLine($"{user.LoginName} created!");
                }
            }
        }
    }

}
