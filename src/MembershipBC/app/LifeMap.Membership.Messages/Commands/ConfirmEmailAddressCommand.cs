using System;
using System.Runtime.Serialization;
using NServiceBus;


namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class ConfirmEmailAddressCommand : ICommand //: MessageBase
    {
        public static ConfirmEmailAddressCommand Create(Guid registrationId, Guid confirmationId)
        {
            return new ConfirmEmailAddressCommand
                       {
                           Id = Guid.NewGuid(),
                           RegistrationId = registrationId,
                           ConfirmationId = confirmationId
                       };
        }


        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid ConfirmationId { get; set; }
    }
}