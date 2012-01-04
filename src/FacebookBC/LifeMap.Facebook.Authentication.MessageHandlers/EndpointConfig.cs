using System;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using LifeMap.Common.Infrastructure;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;

namespace LifeMap.Facebook.Authentication.MessageHandlers
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

            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

            Configure.With()
                .AutofacBuilder(Container)
                .MsmqSubscriptionStorage()
                .WithDefaultMessageSpecifications()
                .XmlSerializer()
                ;
        }

        private IStoreEvents InitializeEventSourcing()
        {
            var dispatcher = new NServiceBusCommitDispatcher();
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingRavenPersistence("FacebookAuthenticationEventStore")
                    .UsingAsynchronousDispatchScheduler(dispatcher)
                    )
                .InitializeStorageEngine()
                .Build();
            return eventStore;
        }


        private IDocumentStore BuildRavenDocumentStore()
        {
            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "FacebookAuthentication"
            }.Initialize();
            return documentStore;
        }
    }
}
