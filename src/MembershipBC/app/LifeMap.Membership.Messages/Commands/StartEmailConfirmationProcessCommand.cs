using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class StartEmailConfirmationProcessCommand : MessageBase
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
        public Guid RegistrationId { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}