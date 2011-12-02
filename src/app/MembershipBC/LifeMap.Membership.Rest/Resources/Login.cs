using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeMap.Membership.Rest.Resources
{
    public class Login
    {
        public Login(Guid registrationId)
        {
            RegistrationId = registrationId;
        }

        public Guid RegistrationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}