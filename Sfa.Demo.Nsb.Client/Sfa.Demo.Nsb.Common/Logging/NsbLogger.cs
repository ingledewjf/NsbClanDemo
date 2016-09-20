namespace Sfa.Demo.Nsb.Common.Logging
{
    using System;

    using NServiceBus.Logging;

    public class NsbLogger : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Debug(string message, Exception exception)
        {
            Console.WriteLine(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message, Exception exception)
        {
            Console.WriteLine(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void Warn(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message, Exception exception)
        {
            Console.WriteLine(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, Exception exception)
        {
            Console.WriteLine(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void Fatal(string message)
        {
            Console.WriteLine(message);
        }

        public void Fatal(string message, Exception exception)
        {
            Console.WriteLine(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public bool IsDebugEnabled => false;

        public bool IsInfoEnabled => false;

        public bool IsWarnEnabled => true;

        bool ILog.IsErrorEnabled => true;

        public bool IsFatalEnabled => true;
    }
}