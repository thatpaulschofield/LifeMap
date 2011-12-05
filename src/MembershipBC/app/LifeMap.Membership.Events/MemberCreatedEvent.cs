using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class MemberCreatedEvent : MessageBase
    {
        public Guid MemberId { get; set; }
    }
}