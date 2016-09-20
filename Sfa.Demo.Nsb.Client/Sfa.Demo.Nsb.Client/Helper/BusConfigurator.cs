namespace Sfa.Demo.Nsb.Client.Helper
{
    using System;
    using System.Collections.Generic;

    using NServiceBus;

    using Common.Commands;
    using Common.Events;
    using Common.Integration;
    
    public static class BusConfigurator
    {
        public static IBus Bus { get; set; }

        public static BusConfiguration GetBusConfiguration()
        {
            BusConfiguration configuration = new BusConfiguration();
            configuration.EndpointName("Demo.Client");
            configuration.UseSerialization<JsonSerializer>();
            configuration.UseTransport<AzureServiceBusTransport>();
            configuration.UseDataBus<AzureDataBus>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            configuration.Conventions().DefiningEventsAs(t => null != t.Namespace && t.Namespace.EndsWith("Events"));
            configuration.Conventions().DefiningCommandsAs(t => null != t.Namespace && t.Namespace.EndsWith("Commands"));

            configuration.CustomConfigurationSource(new CustomConfigurationProvider(
                new Dictionary<Type, string>
                    {
                        { typeof(SayHello), "Demo.Server" },
                        { typeof(IDoSomething), "Demo.Server" }
                    }));

            return configuration;
        }
    }
}