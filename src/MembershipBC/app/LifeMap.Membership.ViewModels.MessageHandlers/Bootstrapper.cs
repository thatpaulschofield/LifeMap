using Autofac;
using Autofac.Core;
using LifeMap.Common.Infrastructure;
//using LifeMap.Common.Infrastructure.Persistence;
//using NServiceBus.UnitOfWork;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace LifeMap.Membership.ViewModels
{
    public class Bootstrapper : IBootstrapper
    {
        public IContainer BootstrapContainer()
        {
            return BootstrapContainer(new ContainerBuilder().Build());
        }

        public IContainer BootstrapContainer(IContainer container)
        {
            new AutomapperConfig().Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterType<RegistrationMessageHandler>()
                .As<RegistrationMessageHandler>()
                .AsImplementedInterfaces();
            var documentStore = BuildDocumentStore(DatabaseNames.MembershipViewModels);
            builder.RegisterInstance(documentStore);
            builder.Register<IDocumentSession>(c =>c.Resolve<IDocumentStore>().OpenSession());
            builder.RegisterType<RegistrationMessageHandler>().As<RegistrationMessageHandler>().AsImplementedInterfaces();
            //builder.RegisterType<RavenUnitOfWork>().As<IManageUnitsOfWork>();
            builder.Update(container);
            return container;
        }

        private IDocumentStore BuildDocumentStore(string databaseName)
        {
            var server = new DocumentStore
                             {
                                 Url = "http://localhost:8080/"
                             }.Initialize();
            server.DatabaseCommands.EnsureDatabaseExists(databaseName);

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