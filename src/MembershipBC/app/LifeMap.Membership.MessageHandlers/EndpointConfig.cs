using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using LifeMap.Common.Infrastructure;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Hosting.Azure;
using NServiceBus.Integration.Azure;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using log4net.Appender;

namespace LifeMap.Membership.MessageHandlers
{
    public class Host : RoleEntryPoint
    {
    }

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization, INameThisEndpoint
    {
        public static IContainer Container;

        public void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConfigOverride>().AsImplementedInterfaces();
            builder.RegisterType<SagaEventStoreRepository>().AsImplementedInterfaces();

            //builder.RegisterType<RegistrationMessageHandler>().As<RegistrationMessageHandler>().AsImplementedInterfaces();
            //builder.RegisterType<EmailConfirmationMessageHandler>().As<EmailConfirmationMessageHandler>().
            //    AsImplementedInterfaces();
            //builder.RegisterType<StubEmailConfirmationMessageHandler>().As<StubEmailConfirmationMessageHandler>().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("MessageHandler"))
                .AsSelf()
                .AsImplementedInterfaces();

            var documentStore = BuildRavenDocumentStore();
            var eventStore = InitializeEventSourcing();
            builder.RegisterInstance(documentStore);
            builder.RegisterInstance(eventStore);
            builder.RegisterInstance(this).AsImplementedInterfaces();
            Container = builder.Build();

            Configure.With(AllAssemblies.Except("NServiceBus.Hosting.Azure.HostProcess.exe"))
                //.Except("Newtonsoft.Json")
                .AutofacBuilder(Container)
                .Log4Net(new ConsoleAppender())
                .AzureConfigurationSource()
                .UnicastBus()
                .JsonSerializer()
                //.RavenPersistence()
                //.RavenSubscriptionStorage()
                //.WithDefaultMessageSpecifications()
                ;
        }

        private IStoreEvents InitializeEventSourcing()
        {
            var dispatcher = new NServiceBusCommitDispatcher(new Lazy<IBus>(ResolveBus));
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingRavenPersistence("MembershipEventStore")
                    .UsingAsynchronousDispatchScheduler(dispatcher)
                )
                .InitializeStorageEngine()
                .Build();
            return eventStore;
        }

        public IBus ResolveBus()
        {
            IBus bus = null;
            do
            {
                try
                {
                    bus = Container.Resolve<IBus>();
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
                
            } while (bus == null);
            return bus;
        }

        private IDocumentStore BuildRavenDocumentStore()
        {
            var documentStore = new DocumentStore
                                    {
                                        Url = "http://localhost:8080/",
                                        DefaultDatabase = "Membership"
                                    }.Initialize();
            return documentStore;
        }

        public string GetName()
        {
            return "lifemap-membership-messagehandlers";
        }
    }

    //public class CustomInitialization : IWantCustomInitialization
    //{
    //    public void Init()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class FinishInitialization : IWantToRunAtStartup
    //{
    //    public void Run()
    //    {
    //        var container = EndpointConfig.Container;
    //        Bus = container.Resolve<IBus>();
    //    }

    //    public IBus Bus
    //    {
    //        set { BusLocator.Bus = value; }
    //    }

    //    public void Stop()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class SubscriptionAuthorizer : IAuthorizeSubscriptions
    //{
    //    public bool AuthorizeSubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
    //    {
    //        return true;
    //    }

    //    public bool AuthorizeUnsubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
    //    {
    //        return true;
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
                    new MessageEndpointMapping { Messages="LifeMap.Membership.Messages", Endpoint="lifemap-membership-messagehandlers" },
                    new MessageEndpointMapping { Messages="LifeMap.EmailGateway.Commands", Endpoint="lifemap-emailgateway" }
                }
            };
        }
    }
}
