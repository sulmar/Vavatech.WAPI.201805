using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using Vavatech.WAPI.IServices;

namespace Vavatech.WAPI.Service.Providers
{
    // Install-Package Microsoft.Aspnet.Identity.Owin
    public class MyAuthorizeServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsersService usersService;

        public MyAuthorizeServerProvider(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Run(()=>Grant(context));
        }

        private void Grant(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identityUser = usersService.Get(context.UserName, context.Password);

            if (identityUser == null)
            {
                context.SetError("invalid_grant", "The username or password is invalid");
            }
            else
            {
                Claim claimName = new Claim("sub", context.UserName);
                Claim claimEmail = new Claim(ClaimTypes.Email, identityUser.Email);
                // Claim claimEmail = new Claim(ClaimTypes.MobilePhone, identityUser.Email);

                Claim claimFields = new Claim("fields", "id;code;name");

                var claims = new List<Claim> { claimName, claimEmail, claimFields };

                var identity = new ClaimsIdentity(claims, context.Options.AuthenticationType);

                context.Validated(identity);
            }
        }
    }
}