using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using NServiceBus;


namespace LifeMap.Membership.Messages.Events
{
    [DataContract, Serializable]
    public class RegisteredEmailAddressConfirmed : IEvent //: MessageBase
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }

        public static RegisteredEmailAddressConfirmed Create(Guid id, Guid registrationId, string emailAddress)
        {
            return new RegisteredEmailAddressConfirmed
                       {
                           Id = id,
                           RegistrationId = registrationId,
                           EmailAddress = emailAddress
                       };
        }
    }
}
