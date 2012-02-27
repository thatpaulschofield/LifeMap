using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Events
{
    [DataContract, Serializable]
    public class OfferAddedToShoppingCartEvent //: MessageBase
    {
        public OfferAddedToShoppingCartEvent()
        {
            
        }

        public Guid OfferId { get; set; }
        public double Total { get; set; }
    }
}
