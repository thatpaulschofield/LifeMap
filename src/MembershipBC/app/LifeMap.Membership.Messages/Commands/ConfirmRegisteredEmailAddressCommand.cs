using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class ConfirmRegisteredEmailAddressCommand : MessageBase
    {
        public static ConfirmRegisteredEmailAddressCommand Create(Guid registrationId, Guid confirmationId, string emailAddress)
        {
            return new ConfirmRegisteredEmailAddressCommand
                       {
                           RegistrationId = registrationId,
                           ConfirmationId = confirmationId,
                           EmailAddress = emailAddress
                       };
        }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid ConfirmationId { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}