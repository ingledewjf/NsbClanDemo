﻿namespace Sfa.Demo.Nsb.Client
{
    using System;

    using NServiceBus;

    using Sfa.Demo.Nsb.Client.ConsoleExtension;
    using Sfa.Demo.Nsb.Client.Helper;
    using Sfa.Demo.Nsb.Common.Commands;

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
                ColourWriter.WriteLine(ConsoleColor.Green, "Select operation:");
                ColourWriter.WriteLine(ConsoleColor.Green, "1 - Send a command");
                Console.WriteLine();

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SendACommand();
                        exiting = PromptForExit();
                        break;
                    default:
                        ColourWriter.WriteLine(ConsoleColor.Red, "Invalid input.");
                        exiting = PromptForExit();
                        break;
                }
            }

            ColourWriter.WriteLine(ConsoleColor.Green, "Press any key to exit...");
            Console.ReadKey();

            BusConfigurator.Bus.Dispose();
        }

        private static bool PromptForExit()
        {
            ColourWriter.WriteLine(ConsoleColor.Green, "Exit? Y for yes, anything else for no");
            var exit = Console.ReadLine();

            return exit?.Trim().ToUpper() == "Y";
        }

        private static void SendACommand()
        {
            BusConfigurator.Bus.Send<SayHelloCommand>(msg => { msg.MyName = "Joe"; });
        }
    }
}
