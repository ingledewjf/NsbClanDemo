namespace Sfa.Demo.Nsb.Client.Handlers
{
    using NServiceBus;

    using Common.Events;

    public class DoSomethingHandler : IHandleMessages<IDoSomething>
    {
        public void Handle(IDoSomething message)
        {
            // Handle IDoSomething here!
        }
    }
}