using System;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Commands
{
    public class AddOfferToShoppingCartCommand : MessageBase
    {
        public Guid OrderId { get; set; }
        public Guid OfferId { get; set; }
    }
}