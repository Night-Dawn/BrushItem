// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using BrushItem.IdentityServer.Data;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace BrushItem.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                    new ApiResource("api1", "My API",new List<string> { "role", "admin", "user" })
            };
        }
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "My API", new List<string> { "role", "admin", "user" })
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                 new Client
                 {
                    ClientId = "tsclient",
                    ClientName = "Test Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent= true,
                    //RedirectUris={ "http://127.0.0.1:8080/callback.html" },
                    RedirectUris={ "https://localhost:5000/swagger/index.html" },
                    //PostLogoutRedirectUris={ "http://127.0.0.1:8080/index.html" },
                    PostLogoutRedirectUris={ "http://localhost:5000/swagger/index.html" },
                    AllowedCorsOrigins ={ "http://localhost:8080", "http://127.0.0.1:8080","http://localhost:5000/" },
                    AllowAccessTokensViaBrowser=true,
                    AllowOfflineAccess =true,
                    AllowedScopes=
                     {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId
                     }
                 },
                 new Client
                 {
                    ClientId = "vclient",
                    ClientName = "Test",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent= true,
                    RedirectUris={ "http://127.0.0.1:8080/callback.html", "https://localhost:8080/callback.html" },
                    PostLogoutRedirectUris={ "https://localhost:8080/" },
                    AllowedCorsOrigins ={ "https://localhost:8080", "https://127.0.0.1:8080"},
                    AllowAccessTokensViaBrowser=true,
                    RequireClientSecret = false,
                    AllowOfflineAccess =true,
                    AlwaysSendClientClaims = true,
                    RequirePkce =false,
                    AccessTokenLifetime = 50,
                    AllowedScopes=
                     {
                        "api1",
                        "openid",
                        "role",
                        "profile",
                        "email",
                         StandardScopes.OfflineAccess,

                     }
                    
                 }

            };

        public static IEnumerable<ApplicationUser> Users =>
            new[]
                {
                    new ApplicationUser
                    {
                        BirthDate = DateTime.Now,
                        Email = "nightdawn97@outlook.com",
                        UserName = "night",
                        NickName = "Night Dawn",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        BirthDate = DateTime.Now,
                        Email = "user2@qq.com",
                        UserName = "user2",
                        NickName = "用户2",
                        EmailConfirmed = true
                    },
                };

                    public static IEnumerable<ApplicationRole> Roles =>
                        new[]
                        {
                    new ApplicationRole
                    {
                        Name = "admin",
                        Description = "管理员",
                    },
                    new ApplicationRole
                    {
                        Name = "user",
                        Description = "用户",
                    },
                    new ApplicationRole
                    {
                        Name = "guest",
                        Description = "访客",
                    },
                };
    }
}