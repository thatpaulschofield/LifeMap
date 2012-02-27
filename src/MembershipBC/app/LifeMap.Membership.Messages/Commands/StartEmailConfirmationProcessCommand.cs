using System;
using System.Runtime.Serialization;
using NServiceBus;


namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class StartEmailConfirmationProcessCommand : ICommand //: MessageBase
    {
        public static StartEmailConfirmationProcessCommand Create(string emailAddress, Guid registrationId)
        {
            return new StartEmailConfirmationProcessCommand
                       {
                           Id = Guid.NewGuid(),
                           EmailAddress = emailAddress,
                           RegistrationId = registrationId
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