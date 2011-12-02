using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using NUnit.Framework;

namespace LifeMap.Membership.ViewModels.Specs
{
    [TestFixture]
    public class Should_be_able_to_map_events_to_viewmodels
    {
        [SetUp]
        public void SetUp()
        {
            new AutomapperConfig().Initialize();
        }

        [Test]
        public void Automapper_should_be_configured_correctly()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
