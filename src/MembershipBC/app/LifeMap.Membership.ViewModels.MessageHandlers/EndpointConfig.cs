﻿using System.Reflection;
using Autofac;
using NServiceBus;

namespace LifeMap.Membership.ViewModels.MessageHandlers
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            var container = new Bootstrapper().BootstrapContainer();


            NServiceBus
                .SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure)
                ;
            NServiceBus
                .Configure.With()
                .Autofac2Builder(container)
                .MsmqSubscriptionStorage()
                .MsmqTransport().IsTransactional(false).PurgeOnStartup(true)
                .BinarySerializer();
        }





    }
}