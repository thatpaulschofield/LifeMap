using System;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using LifeMap.Common.Infrastructure;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using NServiceBus.Hosting.Azure;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace LifeMap.Analysis.MessageHandlers
{
    public class Host : RoleEntryPoint { }

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization
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
                .SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            NServiceBus
                .Configure.With().AutofacBuilder(Container)
                .WithDefaultMessageSpecifications()
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
                Url = "http://localhost:8080/",
                DefaultDatabase = "Analysis"
            }.Initialize();
            return raven;
        }
    }
}
