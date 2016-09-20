namespace Sfa.Demo.Nsb.Client.ConsoleExtension
{
    using System;

    public static class ColourWriter
    {
        private static readonly object MessageLock = new object();

        public static void WriteLine(ConsoleColor color, string message, params object[] args)
        {
            lock (MessageLock)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message, args);
                Console.ResetColor();
            }
        }
    }
}