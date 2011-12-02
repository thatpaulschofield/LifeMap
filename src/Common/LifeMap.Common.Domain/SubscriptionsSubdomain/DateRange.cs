using System;

namespace LifeMap.Common.Domain.SubscriptionsSubdomain
{
    public class DateRange
    {
        private DateRange()
        {
        }

        public DateRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
    }
}