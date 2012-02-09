using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.RegistrationProcess
{
    [Serializable]
    public class EmailAddressConfirmedEvent : MessageBase
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
        public string EmailAddress { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }
    }
}