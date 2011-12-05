using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class MemberSubscribedEvent : MessageBase
    {
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}