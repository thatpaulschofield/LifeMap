using System;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;

namespace LifeMap.Membership.Rest
{
    public class Global : System.Web.HttpApplication
    {
        private static Configure _configure;

        void Application_Start(object sender, EventArgs e)
        {
            NServiceBus.SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            log4net.LogManager.GetLogger(this.GetType()).Info("Starting Application_Start");

            try
            {
                _configure = ConfigureBus();
                InitializeBus();
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(this.GetType()).FatalFormat("Exception during NServiceBus startup: {0}", ex.Message);
                throw;
            }
            AutomapperConfiguration.Initialize();

        }

        private Configure ConfigureBus()
        {
            return NServiceBus.Configure.WithWeb()
                .WithDefaultMessageSpecifications()
                .Log4Net()
                .DefaultBuilder()
                .MsmqTransport()
                .UnicastBus()
                .IsTransactional(false)
                .PurgeOnStartup(false)
                .XmlSerializer()
                .MsmqSubscriptionStorage();
        }

        public static IBus Bus { get; set; }

        public static void InitializeBus()
        {
            Bus = _configure
                            .CreateBus()
                            .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
        }
    }
}
