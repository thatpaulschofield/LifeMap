using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using NServiceBus;
using Raven.Client;
using Raven.Client.Embedded;

namespace LifeMap.Common.Infrastructure
{
    public abstract class ViewModelEndpointConfig
    
    {
        protected string ConnectionStringName { get; set; }

        public void Init()
        {
            var documentStore = BuildRavenDocumentStore();
            var builder = new ContainerBuilder();
            builder.RegisterInstance(documentStore);
            var container = builder.Build();

            NServiceBus
                .SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            NServiceBus
                .Configure.With().Autofac2Builder(container)
                .MsmqSubscriptionStorage()
                .XmlSerializer();
        }



        private IDocumentStore BuildRavenDocumentStore()
        {
            var raven = new EmbeddableDocumentStore
            {
                ConnectionStringName = this.ConnectionStringName,
                UseEmbeddedHttpServer = true,
            };
            raven.Configuration.Port = 8081;
            raven.Initialize();
            return raven;
        }
    }
}
