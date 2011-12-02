using System;
using LifeMap.Common.Domain.SubscriptionsSubdomain;

namespace LifeMap.Membership
{
    public class Subscription
    {
        private Subscription()
        {
        }

        public Subscription(Guid productId, DateRange dates)
        {
            _productId = productId;
            _dates = dates;
        }

        private Guid _productId;
        private DateRange _dates;
    }
}