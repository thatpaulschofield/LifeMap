using System;
using System.Runtime.Serialization;
using NServiceBus;


namespace LifeMap.Membership.Messages.Commands
{
    [DataContract, Serializable]
    public class SelectLoginForRegistrationCommand : ICommand //: MessageBase
    {
        public SelectLoginForRegistrationCommand()
        {
            Id = Guid.NewGuid();
        }

        public SelectLoginForRegistrationCommand(Guid registrationId, Guid loginId) : this()
        {
            RegistrationId = registrationId;
            LoginId = loginId;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid LoginId { get; set; }
    }
}
