using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfa.Demo.Nsb.Server
{
    using NServiceBus;

    public class Program
    {
        public static void Main()
        {
            Console.Title = "Demo.Client";

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("Demo.Client");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            using (var bus = Bus.Create(busConfiguration).Start())
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
