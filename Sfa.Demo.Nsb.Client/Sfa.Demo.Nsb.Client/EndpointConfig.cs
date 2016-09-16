namespace Sfa.Demo.Nsb.Client
{
    using System;
    using System.Collections.Generic;

    using Castle.Windsor;

    using NServiceBus;

    using Integration;
    using Ioc;

    using Sfa.Demo.Nsb.Common.Commands;
    using Sfa.Demo.Nsb.Common.Events;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public static string EndpointName => "Demo.Client";

        public void Customize(BusConfiguration configuration)
        {
            configuration.EndpointName(EndpointName);
            configuration.UseDataBus<AzureDataBus>();

            configuration.Conventions().DefiningEventsAs(t => null != t.Namespace && t.Namespace.EndsWith("Events"));

            configuration.UseSerialization<JsonSerializer>();

            configuration.UseContainer<WindsorBuilder>(c => c.ExistingContainer(new WindsorContainer().Install(new WindsorInstaller())));

            configuration.CustomConfigurationSource(new CustomConfigurationProvider(
                new Dictionary<Type, string>
                    {
                        { typeof(ISayHello), "Demo.Server" },
                        { typeof(IDoSomething), "Demo.Client" }
                    }));
        }
    }
}