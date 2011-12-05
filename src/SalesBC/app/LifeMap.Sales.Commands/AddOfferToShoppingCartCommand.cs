using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Sales.Commands
{
    [Serializable]
    public class AddOfferToShoppingCartCommand : MessageBase
    {
        public Guid OrderId { get; set; }
        public Guid OfferId { get; set; }
    }
}