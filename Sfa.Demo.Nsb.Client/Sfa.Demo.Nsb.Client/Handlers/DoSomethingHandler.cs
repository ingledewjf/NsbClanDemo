namespace Sfa.Demo.Nsb.Client.Handlers
{
    using System;

    using NServiceBus;

    using Common.Commands;

    public class DoSomethingHandler : IHandleMessages<DoSomething>
    {
        public void Handle(DoSomething message)
        {
            // Handle IDoSomething here!
            Console.WriteLine($"I am doing a thing with number {message.Number}!");
        }
    }
}