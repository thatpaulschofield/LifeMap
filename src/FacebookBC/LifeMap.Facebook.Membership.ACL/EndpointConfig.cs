using System;
using System.ComponentModel;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;

namespace LifeMap.Facebook.Membership.ACL
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {

        public void Init()
        {
            SetLoggingLibrary.Log4Net(() => log4net.Config.XmlConfigurator.Configure());

            Configure.With()
                .DefaultBuilder()
                .MsmqSubscriptionStorage()
                .WithDefaultMessageSpecifications()
                .XmlSerializer();
        }
    }
}
