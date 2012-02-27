using System;
using System.Runtime.Serialization;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class MemberCreatedEvent //: MessageBase
    {
        [DataMember]
        public Guid MemberId { get; set; }
    }
}