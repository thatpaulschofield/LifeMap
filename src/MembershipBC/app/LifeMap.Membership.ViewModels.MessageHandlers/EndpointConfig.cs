using System;
using System.Reflection;
using System.Threading;
using Autofac;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using NServiceBus.Config;

namespace LifeMap.Membership.ViewModels.MessageHandlers
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization
    {
        public void Init()
        {
            Thread.Sleep(10);

            var container = new Bootstrapper().BootstrapContainer();


            bool initializedBus = false;
            do
            {
                try
                {
                    NServiceBus
                        .Configure.With()
                        .AutofacBuilder(container)
                        //.Log4Net(new AzureAppender())
                        .AzureMessageQueue()
                        .JsonSerializer()
                        .RavenPersistence()
                        .RavenSagaPersister()
                        .RavenSubscriptionStorage()
                        .WithDefaultMessageSpecifications();
                    initializedBus = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(2000);
                }
            } while (!initializedBus);
        }





    }
}
