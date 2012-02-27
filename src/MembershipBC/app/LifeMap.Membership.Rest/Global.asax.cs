using System;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Integration.Azure;

namespace LifeMap.Membership.Rest
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AutomapperConfiguration.Initialize();
        }

        private static Configure ConfigureBus()
        {
            return NServiceBus.Configure.WithWeb()
                .DefaultBuilder()
                //.WithDefaultMessageSpecifications()
                .Log4Net(new AzureAppender())
                .AzureMessageQueue()
                .AzureSubcriptionStorage()
                .UnicastBus()
                    .ImpersonateSender(false)//.AzureConfigurationSource()
                    .JsonSerializer()
                //.RavenPersistence()
                //.RavenSubscriptionStorage()
                ;
        }

        public static readonly Lazy<IBus> StartBus = new Lazy<IBus>(InitializeBus);
        public static IBus Bus { get; private set; }
        
        public static IBus InitializeBus()
        {
            var startableBus = ConfigureBus().CreateBus();
            var bus = startableBus.Start();
            return bus;
        }

        protected void Application_BeginRequest()
        {
            Bus = StartBus.Value;
        }
    }
}
