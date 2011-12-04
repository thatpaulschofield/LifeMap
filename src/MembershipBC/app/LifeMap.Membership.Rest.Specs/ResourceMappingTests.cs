using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Membership.Rest.Resources;
using NUnit.Framework;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Specs
{
    public class ResourceMappingTests
    {
        public ResourceMappingTests()
        {
            new RastaConfiguration().Configure();
        }

        [Test]
        public void can_map_AddCreditCardInfo()
        {
            new AddCreditCardInfo(Guid.NewGuid()).CreateUri();
        }

        [Test]
        public void can_map_Login()
        {
            new Login(Guid.NewGuid()).CreateUri();
        }

        [Test]
        public void can_map_SubmitRegistration()
        {
            new SubmitRegistration(Guid.NewGuid()).CreateUri();
        }
    }
}
