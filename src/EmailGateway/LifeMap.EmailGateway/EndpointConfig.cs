using System;
using System.Reflection;
using Autofac;
using LifeMap.Common.Infrastructure.Configuration;
using LifeMap.EmailGateway.Commands;
using LifeMap.EmailGateway.Events;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Hosting.Azure;
using NServiceBus.Integration.Azure;
using Raven.Client;
using Raven.Client.Document;

namespace LifeMap.EmailGateway
{
    public class Host : RoleEntryPoint { }

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization//, INameThisEndpoint
    {
        public static IContainer Container;

        public void Init()
        {
            Configure.With(AllAssemblies.Except("NServiceBus.Hosting.Azure.HostProcess.exe"))
                .DefaultBuilder()
                .Log4Net(new AzureAppender())
                .AzureMessageQueue()
                .AzureSubcriptionStorage()
                .UnicastBus()
                    .JsonSerializer()
                ;
        }

        public string GetName()
        {
            return "lifemap-emailgateway";
        }
    }
    
    public class ConfigOverride : IProvideConfiguration<UnicastBusConfig>
    {
        public UnicastBusConfig GetConfiguration()
        {
            return new UnicastBusConfig
            {
                MessageEndpointMappings = new MessageEndpointMappingCollection
                {
                    new MessageEndpointMapping { Messages="LifeMap.EmailGateway.Commands", Endpoint="lifemap-emailgateway" }
                }
            };
        }
    }
}
