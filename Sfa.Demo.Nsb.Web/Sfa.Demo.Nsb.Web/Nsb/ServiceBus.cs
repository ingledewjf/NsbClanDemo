namespace Sfa.Demo.Nsb.Web.Nsb
{
    using NServiceBus;

    public static class ServiceBus
    {
        private static readonly object Lock = new object();

        public static IBus Bus { get; set; }

        public static void Init()
        {
            lock (Lock)
            {
                if (Bus != null)
                {
                    return;
                }

                var cfg = new BusConfiguration();
                cfg.EnableInstallers();
                cfg.UseTransport<AzureServiceBusTransport>();
                cfg.UseSerialization<JsonSerializer>();
                cfg.UsePersistence<InMemoryPersistence>();

                Bus = NServiceBus.Bus.Create(cfg);
            }
        }
    }
}