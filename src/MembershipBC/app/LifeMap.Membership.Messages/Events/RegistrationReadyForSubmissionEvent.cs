using System;
using System.Runtime.Serialization;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class RegistrationReadyForSubmissionEvent //: MessageBase
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}