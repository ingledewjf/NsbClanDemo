namespace Sfa.Demo.Nsb.Web.Handlers
{
    using Common.Commands;

    using NServiceBus;

    using Microsoft.AspNet.SignalR;

    using Hubs;

    public class SayHelloHandler : IHandleMessages<SayHello>
    {
        public void Handle(SayHello message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SayHelloHub>();
            hubContext.Clients.All.showMessage(ConstructGreeting(message.MyName));
        }

        private static string ConstructGreeting(string name)
        {
            return $"Hello, {name}";
        }
    }
}