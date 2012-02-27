using System;
using System.Runtime.Serialization;
using NServiceBus;


namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class ConfirmRegisteredEmailAddressCommand : ICommand//: MessageBase
    {
        public static ConfirmRegisteredEmailAddressCommand Create(Guid registrationId, Guid confirmationId, string emailAddress)
        {
            return new ConfirmRegisteredEmailAddressCommand
                       {
                           Id = Guid.NewGuid(),
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

        [DataMember]
        public Guid Id { get; set; }
    }
}