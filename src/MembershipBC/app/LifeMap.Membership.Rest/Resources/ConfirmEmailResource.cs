using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeMap.Membership.Rest.Resources
{
    public class ConfirmEmailResource
    {
        public Guid confirmationId { get; set; }
        public Guid registrationId { get; set; }
    }
}