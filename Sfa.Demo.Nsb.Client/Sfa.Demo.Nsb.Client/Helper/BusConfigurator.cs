namespace Sfa.Demo.Nsb.Client.Helper
{
    using System;

    using NServiceBus;

    public static class BusConfigurator<T>
    {
        // TODO??
        public static BusConfiguration GetBusConfiguration()
        {
            BusConfiguration configuration = new BusConfiguration();
            configuration.Conventions().DefiningCommandsAs(t => t == typeof(T));
            configuration.UseSerialization<JsonSerializer>();
            configuration.UseTransport<AzureServiceBusTransport>();
            configuration.EnableInstallers();

            return configuration;
        }
    }
}