using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Dispatcher;
using EventStore.Persistence.RavenPersistence;
using EventStore.Serialization;
using LifeMap.Common.Infrastructure;
using LifeMap.Membership.Commands;
using NServiceBus;
using NServiceBus.Unicast;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace LifeMap.Membership.MessageHandlers
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public static IContainer Container;

        public void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NServiceBusCommitDispatcher>()
                .As<NServiceBusCommitDispatcher>()
                .AsImplementedInterfaces()
                .SingleInstance();
            builder.RegisterType<SagaEventStoreRepository>().AsImplementedInterfaces();
            builder.RegisterType<RegistrationMessageHandler>().As<RegistrationMessageHandler>().AsImplementedInterfaces();
            //builder.RegisterType<UnicastBus>().AsImplementedInterfaces();
            var documentStore = BuildRavenDocumentStore();
            var eventStore = InitializeEventSourcing();
            builder.RegisterInstance(documentStore);
            builder.RegisterInstance(eventStore);
            Container = builder.Build();

            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

            Configure.With(
                    //Assembly.GetExecutingAssembly()
                    //typeof(NServiceBus.Configure).Assembly,
                    //typeof(NServiceBus.Config.MessageEndpointMapping).Assembly,
                    //typeof(NServiceBus.Hosting.GenericHost).Assembly,
                    //typeof(StartRegistrationCommand).Assembly,
                    //typeof(Events.MemberCreatedEvent).Assembly
                )
                .Autofac2Builder(Container)
                .MsmqSubscriptionStorage()
                //.DefiningCommandsAs(x => x.Namespace != null && x.Namespace.EndsWith("Commands") && x.Name.EndsWith("Command"))
                //.DefiningEventsAs(x => x.Namespace != null && x.Namespace.EndsWith("Events") && x.Name.EndsWith("Event"))
                .BinarySerializer()
                //.Initialize()
                ;
        }

        private IStoreEvents InitializeEventSourcing()
        {
            var dispatcher = new NServiceBusCommitDispatcher();
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingRavenPersistence("MembershipEventStore")
                    .UsingAsynchronousDispatchScheduler(dispatcher)
                    )
                .InitializeStorageEngine()
                .Build();
            return eventStore;
        }


        private IDocumentStore BuildRavenDocumentStore()
        {
            var server = new DocumentStore
                             {
                                 Url = "http://localhost:8080/"
                             }.Initialize();
            server.DatabaseCommands.EnsureDatabaseExists("Membership");

            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080/databases/Membership",
            }.Initialize();
            return documentStore;
        }
    }

    //public class CustomInitialization : IWantCustomInitialization
    //{
    //    public void Init()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class FinishInitialization : IWantToRunAtStartup
    {
        public void Run()
        {
            var container = EndpointConfig.Container;
            Bus = container.Resolve<IBus>();
        }

        public IBus Bus
        {
            set { BusLocator.Bus = value; }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
