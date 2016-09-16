namespace Sfa.Demo.Nsb.Web
{
    using Microsoft.Owin;
    using Owin;
    using Web;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}