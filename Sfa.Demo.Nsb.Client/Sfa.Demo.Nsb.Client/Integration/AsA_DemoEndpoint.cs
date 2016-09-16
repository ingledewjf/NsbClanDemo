namespace Sfa.Demo.Nsb.Client.Integration
{
    using NServiceBus;

    public interface AsA_DemoEndpoint
    {
        /// <summary>
        /// Allows you to override default NSB settings
        /// </summary>
        /// <param name="configuration"></param>
        void Customize(BusConfiguration configuration);
    }
}