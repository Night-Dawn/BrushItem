using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.IdentityServer.Quickstart.Account
{
    public class CustomTokenService : DefaultTokenService
    {
        public CustomTokenService(
        IClaimsService claimsProvider,
        IReferenceTokenStore referenceTokenStore,
        ITokenCreationService creationService,
        IHttpContextAccessor contextAccessor,
        IdentityServerOptions Options,
        IKeyMaterialService KeyMaterialService,
        ISystemClock clock,
        ILogger<DefaultTokenService> logger) : base(claimsProvider,referenceTokenStore, creationService
            ,  contextAccessor,  clock, KeyMaterialService, Options, logger)
        {
        }

        public override async Task<string> CreateSecurityTokenAsync(Token token)
        {

            string jwt = await base.CreateSecurityTokenAsync(token);

            // store token

            return jwt;
        }
    }
}
