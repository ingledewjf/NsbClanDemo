namespace Sfa.Demo.Nsb.Client
{
    using System;

    using NServiceBus;

    using Sfa.Demo.Nsb.Client.Helper;
    using Sfa.Demo.Nsb.Common.Commands;

    public class Program
    {
        public static void Main(string[] args)
        {
            bool exiting = false;

            while (!exiting)
            {
                Console.WriteLine("Select operation:");
                Console.WriteLine("1 - Send an event");
                Console.WriteLine("2 - Start listening for IDoSomething");
                Console.WriteLine();

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SendAnEvent();
                        exiting = PromptForExit();
                        break;
                    case "2":
                        StartListeningForEvent();
                        PromptForExit();
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        PromptForExit();
                        break;
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static bool PromptForExit()
        {
            Console.WriteLine("Exit? Y for yes, anything else for no");
            var exit = Console.ReadLine();

            return exit?.Trim().ToUpper() == "Y";
        }

        private static void StartListeningForEvent()
        {
            bool eventHandled = false;

            while (!eventHandled)
            {
                System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));

                // your implementation here!
                eventHandled = true;
            }
        }

        private static void SendAnEvent()
        {
            // Your impementation here!

            // Demo implementation
            Console.WriteLine("Input your name");
            var name = Console.ReadLine();

            using (IBus bus = Bus.Create(BusConfigurator<ISayHello>.GetBusConfiguration()))
            {
                bus.Send<ISayHello>("Demo.Server", cmd => { cmd.MyName = name; });
            }
        }
    }
}
