namespace Sfa.Demo.Nsb.Web.Installers
{
    using System.Web.Mvc;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using NServiceBus;

    using Plumbing;
    using Nsb;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            if (ServiceBus.Bus == null)
            {
                ServiceBus.Init();
            }

            container.Register(Component.For<IBus>().Instance(ServiceBus.Bus));
        }
    }
}