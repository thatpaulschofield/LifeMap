using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class MemberCreatedEvent : MessageBase
    {
        public Guid MemberId { get; set; }
    }
}