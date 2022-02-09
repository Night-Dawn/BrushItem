using IdentityServer4.Configuration;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.IdentityServer.Quickstart.Account
{
    public class CustomUserSession: DefaultUserSession
    {
        public CustomUserSession(IHttpContextAccessor httpContextAccessor,
            IAuthenticationHandlerProvider handlers,
            IdentityServerOptions options,
            ISystemClock clock,
            ILogger<DefaultUserSession> logger) :base(httpContextAccessor, handlers,
                options, clock, logger)
        {

        }
        public override async Task<ClaimsPrincipal> GetUserAsync()
        {
            await base.AuthenticateAsync();
            var user = base.Principal;
            return user;
        }
    }
}
