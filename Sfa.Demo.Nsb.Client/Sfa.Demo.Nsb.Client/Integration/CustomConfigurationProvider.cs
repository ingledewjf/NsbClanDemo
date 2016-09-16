namespace Sfa.Demo.Nsb.Client.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using NServiceBus.Config;
    using NServiceBus.Config.ConfigurationSource;

    public class CustomConfigurationProvider : IConfigurationSource
    {
        private readonly IDictionary<Type, string> _typeToEndpointMappings;

        private readonly int _concurrentThreadCount;

        public CustomConfigurationProvider(IDictionary<Type, string> typeToEndpointMappings, int concurrentThreadCount = 1)
        {
            _typeToEndpointMappings = typeToEndpointMappings;
            _concurrentThreadCount = concurrentThreadCount;
        }

        public T GetConfiguration<T>() where T : class, new()
        {
            if (typeof(T) == typeof(UnicastBusConfig) && _typeToEndpointMappings != null)
            {
                return GetUnicastBusConfig() as T;
            }

            if (typeof(T) == typeof(TransportConfig))
            {
                return GetTransportConfig() as T;
            }

            return ConfigurationManager.GetSection(typeof(T).Name) as T;
        }

        private UnicastBusConfig GetUnicastBusConfig()
        {
            var result = new MessageEndpointMappingCollection();

            foreach (var mapping in _typeToEndpointMappings)
            {
                result.Add(new MessageEndpointMapping
                               {
                                   AssemblyName = mapping.Key.Assembly.GetName().Name,
                                   TypeFullName = mapping.Key.FullName,
                                   Endpoint = mapping.Value
                               });
            }

            return new UnicastBusConfig {MessageEndpointMappings = result};
        }

        private TransportConfig GetTransportConfig()
        {
            return new TransportConfig
                       {
                           MaxRetries = 5,
                           MaximumMessageThroughputPerSecond = 0,
                           MaximumConcurrencyLevel = _concurrentThreadCount
                       };
        }
    }
}