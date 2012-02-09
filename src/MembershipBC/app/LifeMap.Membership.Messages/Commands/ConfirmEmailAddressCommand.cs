using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class ConfirmEmailAddressCommand : MessageBase
    {
        public static ConfirmEmailAddressCommand Create(Guid registrationId, Guid confirmationId)
        {
            return new ConfirmEmailAddressCommand
                       {
                           RegistrationId = registrationId,
                           ConfirmationId = confirmationId
                       };
        }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid ConfirmationId { get; set; }
    }
}