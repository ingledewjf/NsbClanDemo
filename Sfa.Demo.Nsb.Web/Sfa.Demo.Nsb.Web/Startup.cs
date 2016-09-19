using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Sfa.Demo.Nsb.Web.Startup))]
namespace Sfa.Demo.Nsb.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}