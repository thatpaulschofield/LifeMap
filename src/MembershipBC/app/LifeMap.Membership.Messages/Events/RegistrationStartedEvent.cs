using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class RegistrationStartedEvent : MessageBase
    {
        public RegistrationStartedEvent()
        {
        }

        public RegistrationStartedEvent(Guid registrationId, string firstName, string lastName, string emailAddress)
        {
            Id = registrationId;
            RegistrationId = registrationId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public Guid RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return String.Format("A registration has started. Id {0}, for [{1} {2}] at [{3}]", RegistrationId, FirstName, LastName,
                                 EmailAddress);
        }
    }
}
