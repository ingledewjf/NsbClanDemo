namespace Sfa.Demo.Nsb.Web.Hubs
{
    using System;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using NServiceBus;

    using Sfa.Demo.Nsb.Common.Commands;
    using Sfa.Demo.Nsb.Web.Nsb;

    public class SayHelloHub : Hub
    {
        public void ShowMessage(string name)
        {
            var greeting = ConstructGreeting(name);

            Clients.All.showMessage(greeting);
        }

        public void Publish(string number)
        {
            int numToPublish;

            var isNumber = int.TryParse(number, out numToPublish);

            try
            {
                if (isNumber)
                {
                    ServiceBus.Bus.Send<DoSomething>(msg => { msg.Number = numToPublish; });
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                Console.WriteLine(test);
            }
        }

        private static string ConstructGreeting(string name)
        {
            return $"Hello, {name}";
        }
    }
}