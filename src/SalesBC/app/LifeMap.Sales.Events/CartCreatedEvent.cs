using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Events
{
    [Serializable]
    public class CartCreatedEvent : MessageBase
    {
        public CartCreatedEvent()
        {
            Id = Guid.NewGuid();
        }

        public CartCreatedEvent(Guid cartId)
        {
            Id = cartId;
            CartId = cartId;
        }

        public Guid CartId { get; set; }
    }
}
