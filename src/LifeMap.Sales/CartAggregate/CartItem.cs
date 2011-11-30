using System;

namespace LifeMap.Sales.CartAggregate
{
    public class CartItem
    {
        private CartItem()
        {
        }

        public CartItem(Guid offerId, Money total)
        {
            OfferId = offerId;
            Total = total;
        }

        public Money Total { get; set; }
        public Guid OfferId { get; set; }
    }
}