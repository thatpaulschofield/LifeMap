using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class RegistrationStartedEvent : MessageBase
    {
        public RegistrationStartedEvent()
        {
        }

        public RegistrationStartedEvent(Guid id, string firstName, string lastName, string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
