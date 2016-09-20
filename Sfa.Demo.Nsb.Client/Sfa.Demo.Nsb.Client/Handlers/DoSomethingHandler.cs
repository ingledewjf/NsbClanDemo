namespace Sfa.Demo.Nsb.Client.Handlers
{
    using System;

    using NServiceBus;

    using Common.Commands;

    using Sfa.Demo.Nsb.Common.Events;

    public class DoSomethingHandler : IHandleMessages<IDoSomething>
    {
        public void Handle(IDoSomething message)
        {
            // Handle IDoSomething here!
            Console.WriteLine($"I am doing a thing with number {message.Number}!");
        }
    }
}