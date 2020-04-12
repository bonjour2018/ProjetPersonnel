using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(WebApiLoginLogout.Startup))]

namespace WebApiLoginLogout
{
    public class Startup
    {
        [EnableCorsAttribute("http://localhost:4200", "*", "*")]
        public void Configuration(IAppBuilder app)
        {
            // Pour plus d'informations sur la façon de configurer votre application, consultez http://go.microsoft.com/fwlink/?LinkID=316888
            //app.UseCors(CorsOptions.AllowAll);
            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            app.UseCors(CorsOptions.AllowAll);
            //app.config.EnableCors(cors);

            //pour ajouter Token Base Authentication
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
