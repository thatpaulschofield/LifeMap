using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using LifeMap.Common.Infrastructure;
using LifeMap.Membership.MessageHandlers;
using NServiceBus;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace IntegrationTests
{
    public class MembershipMessageHandlerBootstrapper
    {
        private static ContainerBuilder _builder;

        static MembershipMessageHandlerBootstrapper()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<RegistrationMessageHandler>();
            _builder.RegisterInstance(new DocumentStore { ConnectionStringName = "MembershipEventStore"}).AsImplementedInterfaces();
            _builder.RegisterType<SagaEventStoreRepository>().AsImplementedInterfaces();
            _builder.RegisterInstance(InitializeEventSourcing());
        }

        public static void RegisterBus(IBus bus)
        {
            _builder.RegisterInstance(bus);
        }

        public static IContainer BootstrapContainer()
        {
            return _builder.Build();
        }

        private static IStoreEvents InitializeEventSourcing()
        {
            var dispatcher = new NServiceBusCommitDispatcher();
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingInMemoryPersistence()
                    .UsingSynchronousDispatchScheduler(dispatcher)
                    )
                .InitializeStorageEngine()
                .Build();
            return eventStore;
        }
    }
}
