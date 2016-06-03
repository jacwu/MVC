using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(ELibrary.API.Startup))]

namespace ELibrary.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            AutofacConfig.Register(config);

            app.UseWebApi(config);

        }
    }
}
