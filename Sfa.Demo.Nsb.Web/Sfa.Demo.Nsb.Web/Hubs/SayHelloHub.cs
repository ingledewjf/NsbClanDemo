namespace Sfa.Demo.Nsb.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    using Sfa.Demo.Nsb.Common.Events;
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

            if (isNumber)
            {
                ServiceBus.Bus.Publish<IDoSomething>(msg => { msg.Number = numToPublish; });
            }
        }

        private static string ConstructGreeting(string name)
        {
            return $"Hello, {name}";
        }
    }
}