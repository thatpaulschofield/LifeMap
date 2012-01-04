using System;
using System.Reflection;
using Autofac;
using LifeMap.Common.Infrastructure.Configuration;
using LifeMap.EmailGateway.Commands;
using LifeMap.EmailGateway.Events;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;

namespace LifeMap.EmailGateway
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public static IContainer Container;

        public void Init()
        {
            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

            Configure.With()
                .DefaultBuilder()
                .MsmqSubscriptionStorage()
                .WithDefaultMessageSpecifications()
                //.DefiningCommandsAs(x => x.Namespace != null && x.Namespace.StartsWith("LifeMap") && (x.Namespace.EndsWith("Commands") || x.Name.EndsWith("Command")))
                //.DefiningEventsAs(x => x.Namespace != null && x.Namespace.StartsWith("LifeMap") && (x.Namespace.EndsWith("Events") || x.Name.EndsWith("Event")))
                .XmlSerializer()
                ;
        }
    }
}
