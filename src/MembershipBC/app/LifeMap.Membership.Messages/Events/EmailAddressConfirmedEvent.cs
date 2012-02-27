using System;
using System.Runtime.Serialization;
using NServiceBus;

namespace LifeMap.Membership.RegistrationProcess
{
    [DataContract, Serializable]
    public class EmailAddressConfirmedEvent : IEvent //: MessageBase
    {
        public static EmailAddressConfirmedEvent Create(Guid id, Guid registrationId, string emailAddress)
        {
            return new EmailAddressConfirmedEvent
                       {
                           Id = id,
                           RegistrationId = registrationId,
                           EmailAddress = emailAddress
                       };
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }
    }
}