using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using EventStore;
using LifeMap.Common.Infrastructure;
using LifeMap.Membership.ViewModels;
using NServiceBus;
using log4net;

namespace LifeMap.Tools.ViewBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            Console.WriteLine("Starting");
            new ViewBuilder();

            Console.WriteLine("Finished.");
            Console.ReadKey();
        }
    }

    public class ViewBuilder
    {
        private ILog _logger;

        public ViewBuilder()
        {
            _logger = log4net.LogManager.GetLogger(this.GetType());

            Type genericMessageHandlerType = typeof (IHandleMessages<>);
            var eventStore = new PersistenceWireup(
                Wireup.Init()
                    .UsingRavenPersistence("MembershipEventStore")
                )
                .InitializeStorageEngine()
                .Build();
            
            var container = BootstrapMessageHandlers();


            var commits = eventStore.Advanced.GetFrom(new DateTime(1900, 1, 1));
            foreach (var commit in commits)
            {
                foreach (var @event in commit.Events.Select(x => x.Body))
                {
                    Type eventType = @event.GetType();
                    _logger.InfoFormat("Handling event '{0}'", @eventType.Name);
                    Type specificEventHandlerType = genericMessageHandlerType.MakeGenericType(eventType);
                    Type enumerableOfEventHandlerType = typeof (IEnumerable<>).MakeGenericType(specificEventHandlerType);
                    var handlers = container.Resolve(enumerableOfEventHandlerType) as IEnumerable;
                    bool hadHandlers = false;
                    if (handlers != null)
                    {
                        foreach (var handler in handlers)
                        {
                            hadHandlers = true;
                            _logger.InfoFormat("  Processing event with handler {0}", handler.GetType());
                            var genericHandleMethod =
                                handler.GetType().GetMethods().Where(
                                    m => m.Name == "Handle" && m.GetParameters()[0].ParameterType == eventType).
                                    SingleOrDefault();
                            if (genericHandleMethod != null)
                            {
                                genericHandleMethod.Invoke(handler, new object[]{ @event });
                            }
                        }
                    }
                    if (!hadHandlers)
                    {
                        _logger.InfoFormat("No handlers found for event type {0}", eventType.Name);
                    }
                }
            }
        }

        private IContainer BootstrapMessageHandlers()
        {
            var container = new ContainerBuilder().Build();
            var assemblyName = ConfigurationManager.AppSettings["IncludeAssembly"];
            var assembly = Assembly.Load(assemblyName);
            var bootstrappers = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof (IBootstrapper)));
            foreach (var bootstrapperType in bootstrappers)
            {
                IBootstrapper bootstrapper = Activator.CreateInstance(bootstrapperType) as IBootstrapper;
                if (bootstrapper != null) bootstrapper.BootstrapContainer(container);
            }
            return container;
        }
    }
    
}
