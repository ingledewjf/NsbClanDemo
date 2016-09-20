namespace Sfa.Demo.Nsb.Web.Hubs
{
    using System;

    using Microsoft.AspNet.SignalR;

    using Common.Events;
    using Nsb;

    public class SayHelloHub : Hub
    {
        public void Publish(string number)
        {
            int numToPublish;

            var isNumber = int.TryParse(number, out numToPublish);

            try
            {
                if (isNumber)
                {
                    ServiceBus.Bus.Publish<IDoSomething>(msg => { msg.Number = numToPublish; });
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                Console.WriteLine(test);
            }
        }
    }
}