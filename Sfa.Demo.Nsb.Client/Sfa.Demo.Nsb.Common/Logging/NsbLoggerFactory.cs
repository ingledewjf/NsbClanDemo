namespace Sfa.Demo.Nsb.Common.Logging
{
    using System;

    using NServiceBus.Logging;

    public class NsbLoggerFactory : ILoggerFactory
    {
        public ILog GetLogger(Type type)
        {
            return new NsbLogger();
        }

        public ILog GetLogger(string name)
        {
            return new NsbLogger();
        }
    }
}