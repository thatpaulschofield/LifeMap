using System;
using System.Configuration;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using Facebook;
using LifeMap.Common.Infrastructure;
using LifeMap.Facebook.Authentication.MessageHandlers;
using LifeMap.Facebook.MessageHandlers;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace LifeMap.Facebook
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
            builder.RegisterType<FacebookRegistrationMessageHandler>().As<FacebookRegistrationMessageHandler>().
                AsImplementedInterfaces();
            builder.RegisterInstance(GetFacebookConfig());
            var documentStore = BuildRavenDocumentStore();
            var eventStore = InitializeEventSourcing();
            builder.RegisterInstance(documentStore);
            builder.RegisterInstance(eventStore);
            Container = builder.Build();

            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

            Configure.With()
                .Autofac2Builder(Container)
                .MsmqSubscriptionStorage()
                //.DefiningCommandsAs(x => x.Namespace != null && x.Namespace.EndsWith("Commands") && x.Name.EndsWith("Command"))
                //.DefiningEventsAs(x => x.Namespace != null && x.Namespace.EndsWith("Events") && x.Name.EndsWith("Event"))
                .BinarySerializer()
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
            var server = new DocumentStore
                             {
                                 Url = "http://localhost:8080/"
                             }.Initialize();
            server.DatabaseCommands.EnsureDatabaseExists("Facebook");

            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080/databases/Facebook",
            }.Initialize();
            return documentStore;
        }

        private IFacebookApplication GetFacebookConfig()
        {
            var settings = ConfigurationManager.GetSection("facebookSettings");

            return settings as IFacebookApplication;
        }
    }
    

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
