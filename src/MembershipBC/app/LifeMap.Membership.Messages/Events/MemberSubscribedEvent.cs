using System;
using System.Runtime.Serialization;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class MemberSubscribedEvent //: MessageBase
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid MemberId { get; set; }

        [DataMember]
        public Guid ProductId { get; set; }

        [DataMember]
        public DateTime BeginDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }
    }
}