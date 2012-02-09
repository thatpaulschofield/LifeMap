using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class EmailConfirmationProcessStartedEvent : MessageBase
    {
        public static EmailConfirmationProcessStartedEvent Create(Guid id, Guid registrationId, string emailAddress)
        {
            return new EmailConfirmationProcessStartedEvent
                       {
                           Id = id,
                           RegistrationId = registrationId,
                           EmailAddress = emailAddress
                       };
        }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}