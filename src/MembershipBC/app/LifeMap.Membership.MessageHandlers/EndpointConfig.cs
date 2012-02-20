using System;
using System.Threading;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using LifeMap.Common.Infrastructure;
using LifeMap.Common.Infrastructure.Configuration;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Hosting.Azure;
using NServiceBus.Integration.Azure;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace LifeMap.Membership.MessageHandlers
{
    public class Host : RoleEntryPoint { }

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization
    {
        public static IContainer Container;

        public void Init()
        {
            Thread.Sleep(10);

            var builder = new ContainerBuilder();

            builder.RegisterType<NServiceBusCommitDispatcher>()
                .As<NServiceBusCommitDispatcher>()
                .AsImplementedInterfaces()
                .SingleInstance();
            builder.RegisterType<SagaEventStoreRepository>().AsImplementedInterfaces();
            builder.RegisterType<RegistrationMessageHandler>().As<RegistrationMessageHandler>().AsImplementedInterfaces();
            var documentStore = BuildRavenDocumentStore();
            var eventStore = InitializeEventSourcing();
            builder.RegisterInstance(documentStore);
            builder.RegisterInstance(eventStore);
            Container = builder.Build();

            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

            bool initializedBus = false;
            do
            {
                try
                {
                    Configure.With(AllAssemblies.Except("Newtonsoft.Json").And("NServiceBus.Hosting.Azure.HostProcess"))
                        .AutofacBuilder(Container)
                        .Log4Net(new AzureAppender())
                        .AzureMessageQueue()
                        .JsonSerializer()
                        .RavenPersistence()
                        .RavenSagaPersister()
                        .RavenSubscriptionStorage()
                        .WithDefaultMessageSpecifications();

                    initializedBus = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(2000);
                }
            } while (!initializedBus);
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
            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "Membership"
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
