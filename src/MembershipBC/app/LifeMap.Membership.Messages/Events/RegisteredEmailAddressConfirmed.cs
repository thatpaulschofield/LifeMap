using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Messages.Events
{
    [Serializable]
    public class RegisteredEmailAddressConfirmed : MessageBase
    {
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
