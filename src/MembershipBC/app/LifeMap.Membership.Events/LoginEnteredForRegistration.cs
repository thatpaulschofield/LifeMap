using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class LoginEnteredForRegistration : MessageBase
    {
        public LoginEnteredForRegistration()
        {
        }

        public LoginEnteredForRegistration(Guid registrationId, string userName, string password)
        {
            RegistrationId = registrationId;
            UserName = userName;
            Password = password;
        }

        public Guid RegistrationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
