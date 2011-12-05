using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Sales.Commands
{
    [Serializable]
    public class CreateOfferCommand : MessageBase
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int DurationInDays { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public double Price;
    }
}
