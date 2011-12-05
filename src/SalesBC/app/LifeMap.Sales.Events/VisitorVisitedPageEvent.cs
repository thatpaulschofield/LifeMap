using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Sales.Events
{
    [Serializable]
    public class VisitorVisitedPageEvent : MessageBase
    {
        public string PageUrl { get; set; }
        public DateTime TimeOfVisit { get; set; }
    }
}