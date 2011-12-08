using System;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Events
{
    [Serializable]
    public class SubscriptionPurchasedEvent : MessageBase
    {
        public Guid LoginId { get; set; }
        public Guid ProductId { get; set; }
        public int TermInDays { get; set; }

        public Guid MemberId { get; set; }
    }
}