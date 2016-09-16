namespace Sfa.Demo.Nsb.Web.Handlers
{
    using Common.Commands;

    using NServiceBus;

    using Microsoft.AspNet.SignalR;

    using Hubs;

    public class SayHelloHandler : IHandleMessages<ISayHello>
    {
        public void Handle(ISayHello message)
        {
            // var hub = new SayHelloHub();

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SayHelloHub>();
            hubContext.Clients.All.showMessage(ConstructGreeting(message.MyName));

            // hub.NewSayHelloMessage(message.MyName);
        }

        private static string ConstructGreeting(string name)
        {
            return $"Hello, {name}";
        }
    }
}