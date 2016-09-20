namespace Sfa.Demo.Nsb.Web
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Autofac;
    using Autofac.Integration.Mvc;

    using NServiceBus;

    using Sfa.Demo.Nsb.Common.Integration;
    using Sfa.Demo.Nsb.Web.Hubs;
    using Sfa.Demo.Nsb.Web.Nsb;

    using RegistrationExtensions = Autofac.Integration.SignalR.RegistrationExtensions;

    public class MvcApplication : System.Web.HttpApplication
    {
        private IBus _bus;

        protected MvcApplication()
        {
        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SayHelloHub>().AsSelf().ExternallyOwned().SingleInstance();

            RegistrationExtensions.RegisterHubs(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("Demo.Server");
            busConfiguration.UseTransport<AzureServiceBusTransport>();
            busConfiguration.Conventions().DefiningEventsAs(t => null != t.Namespace && t.Namespace.EndsWith("Events"));
            busConfiguration.Conventions().DefiningCommandsAs(t => null != t.Namespace && t.Namespace.EndsWith("Commands"));
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.CustomConfigurationSource(new CustomConfigurationProvider(
                new Dictionary<Type, string>()));
            busConfiguration.UseContainer<AutofacBuilder>(
                customizations =>
                {
                    customizations.ExistingLifetimeScope(container);
                });
            
            busConfiguration.EnableInstallers();

            var startableBus = Bus.Create(busConfiguration);
            _bus = startableBus.Start();

            ServiceBus.Bus = _bus;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _bus?.Dispose();
        }
    }
}
