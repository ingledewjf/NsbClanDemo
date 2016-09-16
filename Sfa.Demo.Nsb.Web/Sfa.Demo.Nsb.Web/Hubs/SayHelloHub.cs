namespace Sfa.Demo.Nsb.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class SayHelloHub : Hub
    {
        public void ShowMessage(string name)
        {
            var greeting = ConstructGreeting(name);

            Clients.All.showMessage(greeting);
        }

        private static string ConstructGreeting(string name)
        {
            return $"Hello, {name}";
        }
    }
}