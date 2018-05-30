using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Service.Providers;

namespace Vavatech.WAPI.MyService
{

    // Install-Package Microsoft.AspNet.WebApi.OwinSelfHost
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            using (var config = new HttpConfiguration())
            {
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });

                ConfigureOAuth(appBuilder);

                appBuilder.UseWebApi(config);
            }
        }

        private void ConfigureOAuth(IAppBuilder appBuilder)
        {
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                Provider = new MyAuthorizeServerProvider(new MockUsersService())
            };

            appBuilder.UseOAuthAuthorizationServer(options);

            var tokenOptions = new OAuthBearerAuthenticationOptions();
            appBuilder.UseOAuthBearerAuthentication(tokenOptions);
        }
    }
}
