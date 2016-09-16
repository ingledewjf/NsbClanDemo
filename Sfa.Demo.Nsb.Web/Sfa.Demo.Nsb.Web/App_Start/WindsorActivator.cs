using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(Sfa.Demo.Nsb.Web.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(Sfa.Demo.Nsb.Web.App_Start.WindsorActivator), "Shutdown")]

namespace Sfa.Demo.Nsb.Web.App_Start
{
    public static class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }
        
        public static void Shutdown()
        {
            bootstrapper?.Dispose();
        }
    }
}