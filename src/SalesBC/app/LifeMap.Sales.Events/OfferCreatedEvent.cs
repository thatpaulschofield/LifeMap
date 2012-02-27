using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Events
{
    [DataContract, Serializable]
    public class OfferCreatedEvent //: MessageBase
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int DurationInDays { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public double Price { get; set; }
    }
}
