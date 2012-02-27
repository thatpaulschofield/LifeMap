using System;
using System.Runtime.Serialization;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class EmailConfirmationProcessStartedEvent : IEvent //: MessageBase
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
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}