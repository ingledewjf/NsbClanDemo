namespace Sfa.Demo.Nsb.Client
{
    using System;

    using NServiceBus;

    using Sfa.Demo.Nsb.Client.ConsoleExtension;
    using Sfa.Demo.Nsb.Client.Helper;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Demo.Client";

            var busConfig = BusConfigurator.GetBusConfiguration();
            busConfig.EnableInstallers();

            ColourWriter.WriteLine(ConsoleColor.Green, "Starting NServiceBus...");
            BusConfigurator.Bus = Bus.Create(busConfig).Start();
            ColourWriter.WriteLine(ConsoleColor.Green, "NServiceBus started successfully.");
            Console.WriteLine();

            bool exiting = false;

            while (!exiting)
            {
                ColourWriter.WriteLine(ConsoleColor.Green, "Choose an option:");
                ColourWriter.WriteLine(ConsoleColor.Green, "1 - Send a command");
                ColourWriter.WriteLine(ConsoleColor.Green, "2 - Exit");

                var userOption = Console.ReadLine();

                switch (userOption?.Trim())
                {
                    case "1":
                        // Your implementation for sending a command here
                        break;
                    case "2":
                        exiting = true;
                        break;
                    default:
                        ColourWriter.WriteLine(ConsoleColor.Red, "Invalid option. Please try again.");
                        break;
                }
            }
            ColourWriter.WriteLine(ConsoleColor.Green, "Press any key to exit...");
            Console.ReadKey();

            BusConfigurator.Bus.Dispose();
        }
    }
}
