using System;
using System.Configuration;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using Facebook;
using LifeMap.Common.Infrastructure;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace LifeMap.Facebook.MessageHandlers
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
            builder.RegisterType<FeedImportSagaMessageHandler>().As<FeedImportSagaMessageHandler>().AsImplementedInterfaces();
            builder.RegisterInstance(GetFacebookConfig());
            var documentStore = BuildRavenDocumentStore();
            var eventStore = InitializeEventSourcing();
            builder.RegisterInstance(documentStore);
            builder.RegisterInstance(eventStore);
            Container = builder.Build();

            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

            Configure.With()
                .AutofacBuilder(Container)
                .MsmqSubscriptionStorage()
                .XmlSerializer()
                ;
        }

        private IStoreEvents InitializeEventSourcing()
        {
            var dispatcher = new NServiceBusCommitDispatcher();
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingRavenPersistence("FacebookEventStore")
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
                DefaultDatabase = "Facebook"
            }.Initialize();
            return documentStore;
        }

        private IFacebookApplication GetFacebookConfig()
        {
            var settings = ConfigurationManager.GetSection("facebookSettings");

            return settings as IFacebookApplication;
        }
    }
}
