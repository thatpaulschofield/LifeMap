using System;
using Autofac;
using CommonDomain.Persistence.EventStore;
using EventStore;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace LifeMap.Membership.ViewModels
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            new AutomapperConfig().Initialize();

            var builder = new ContainerBuilder();
            var documentStore = BuildDocumentStore(DatabaseNames.MembershipViewModels);
            builder.RegisterInstance(documentStore);
            builder.Register<IDocumentSession>(
                c =>
                    {
                        var docStore = c.Resolve<IDocumentStore>();
                        return docStore.OpenSession();
                    });

            var container = builder.Build();

            NServiceBus
                .SetLoggingLibrary.Log4Net();
            NServiceBus
                .Configure.With().Autofac2Builder(container)
                .MsmqSubscriptionStorage()
                .XmlSerializer();
        }

        

        private IDocumentStore BuildDocumentStore(string databaseName)
        {
            var raven = new DocumentStore
                            {
                                Url = "http://localhost:8080/databases/" + databaseName
                            }
                            .Initialize();
            return raven;
        }

        private void RegisterNamedDocumentStore(ContainerBuilder builder, string databaseName)
        {
            builder.RegisterInstance(BuildDocumentStore(databaseName)).Named<IDocumentStore>(databaseName);
        }

    }
}
