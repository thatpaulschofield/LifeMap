using System;
using System.Runtime.Serialization;
using NServiceBus;


namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class SubmitRegistrationCommand : ICommand //: MessageBase
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}