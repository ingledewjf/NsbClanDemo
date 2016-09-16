namespace Sfa.Demo.Nsb.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.Windsor;

    using Sfa.Demo.Nsb.Web.Installers;
    using Sfa.Demo.Nsb.Web.Nsb;

    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer _container;

        protected MvcApplication()
        {
            _container = new WindsorContainer().Install(new ControllersInstaller());
        }

        protected void Application_Start()
        {
            ServiceBus.Init();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
