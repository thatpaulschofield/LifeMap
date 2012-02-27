using System;
using System.Reflection;
using System.Threading;
using Autofac;
using LifeMap.Common.Infrastructure.Configuration;
using LifeMap.Membership.Events;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Hosting.Azure;
using NServiceBus.Integration.Azure;
using log4net.Appender;

namespace LifeMap.Membership.ViewModels.MessageHandlers
{
    public class Host : RoleEntryPoint { }
    
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization, INameThisEndpoint
    {
        public void Init()
        {
            var container = new Bootstrapper().BootstrapContainer();

            NServiceBus
                .Configure.With(AllAssemblies.Except("NServiceBus.Hosting.Azure.HostProcess.exe"))
                .AutofacBuilder(container)
                .Log4Net(new ConsoleAppender())
                .AzureConfigurationSource()
                .AzureSubcriptionStorage()
                .AzureMessageQueue()
                .JsonSerializer()
                //.RavenPersistence()
                //.RavenSubscriptionStorage()
                //.WithDefaultMessageSpecifications()
                ;
        }


        public string GetName()
        {
            return "lifemap-membership-viewmodels-messagehandlers";
        }
    }

    //public class Subscribe : IWantToRunWhenConfigurationIsComplete
    //{
    //    private readonly IBus _bus;

    //    public Subscribe(IBus bus)
    //    {
    //        _bus = bus;
    //    }
    //    public void Run()
    //    {
    //        _bus.Subscribe<RegistrationStartedEvent>();
    //    }
    //}
    class ConfigOverride : IProvideConfiguration<UnicastBusConfig>
    {
        public UnicastBusConfig GetConfiguration()
        {
            return new UnicastBusConfig
            {
                MessageEndpointMappings = new MessageEndpointMappingCollection
                {
                    new MessageEndpointMapping { Messages="LifeMap.Membership.Messages", Endpoint="lifemap-membership-viewmodels-messagehandlers" },
                }
            };
        }
    }
}
