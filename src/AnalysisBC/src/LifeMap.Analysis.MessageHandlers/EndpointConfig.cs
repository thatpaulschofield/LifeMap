using System;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using LifeMap.Common.Infrastructure;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;

namespace LifeMap.Analysis.MessageHandlers
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

            var documentStore = BuildRavenDocumentStore();
            var eventStore = InitializeEventSourcing();
            builder.RegisterInstance(documentStore);
            builder.RegisterInstance(eventStore);
            Container = builder.Build();

            NServiceBus
                .SetLoggingLibrary.Log4Net();
            NServiceBus
                .Configure.With().Autofac2Builder(Container)
                .MsmqSubscriptionStorage()
                .XmlSerializer();
        }

        private IStoreEvents InitializeEventSourcing()
        {
            var dispatcher = new NServiceBusCommitDispatcher();
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingRavenPersistence("AnalysisEventStore")
                    .UsingAsynchronousDispatchScheduler(dispatcher)
                    )
                .InitializeStorageEngine()
                .Build();
            return eventStore;
        }


        private IDocumentStore BuildRavenDocumentStore()
        {
            var raven = new DocumentStore
            {
                Url = "http://localhost:8080/databases/Analysis",
            }.Initialize();
            return raven;
        }
    }


    public class FinishInitialization : IWantToRunAtStartup
    {
        public void Run()
        {
            var container = EndpointConfig.Container;

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
