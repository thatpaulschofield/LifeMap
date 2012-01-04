using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using LifeMap.Common.Infrastructure;
using LifeMap.Membership.Commands;
using LifeMap.Membership.MessageHandlers;
using NServiceBus;
using NServiceBus.Testing;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class RegistrationTests
    {
        private IBus _bus;

        [SetUp]
        public void SetUp()
        {
            _bus = Configure.With()
                .DefaultBuilder()
                .MsmqTransport()
                .UnicastBus()
                .InMemorySubscriptionStorage()
                .XmlSerializer()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

        }

        [Test]
        public void Foo()
        {
        }
    }

    
}
