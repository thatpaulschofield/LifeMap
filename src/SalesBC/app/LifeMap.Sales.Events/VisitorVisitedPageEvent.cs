using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Events
{
    [DataContract, Serializable]
    public class VisitorVisitedPageEvent //: MessageBase
    {
        public string PageUrl { get; set; }
        public DateTime TimeOfVisit { get; set; }
    }
}