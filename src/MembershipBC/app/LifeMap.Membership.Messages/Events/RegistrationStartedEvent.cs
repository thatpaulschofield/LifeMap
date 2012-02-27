using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using NServiceBus;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class RegistrationStartedEvent : IEvent //: IMessage
    {
        public RegistrationStartedEvent()
        {
        }

        public RegistrationStartedEvent(Guid registrationId, string firstName, string lastName, string emailAddress, string password)
        {
            Id = registrationId;
            RegistrationId = registrationId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string Password { get; set; }

        public override string ToString()
        {
            return String.Format("A registration has started. Id {0}, for [{1} {2}] at [{3}]", RegistrationId, FirstName, LastName,
                                 EmailAddress);
        }
    }
}
