using System;
using System.Collections.Generic;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.Sales.Events;
using NServiceBus;

namespace LifeMap.Sales.CartAggregate
{
    public class ShoppingCart : SagaBase<IMessage>
    {
        private List<CartItem> _lines = new List<CartItem>();

        public ShoppingCart()
        {
            base.Register<CartCreatedEvent>(Apply);
            base.Register<OfferAddedToShoppingCartEvent>(Apply);
        }

        public void Create(Guid cartId)
        {
            base.Transition(new CartCreatedEvent(cartId));
        }

        public void AddOffer(Offer offer)
        {
            base.Transition(new OfferAddedToShoppingCartEvent{OfferId = offer.Id, Total = offer.GetPrice()});
        }

        protected void Apply(OfferAddedToShoppingCartEvent @event)
        {
            _lines.Add(new CartItem(@event.OfferId, @event.Total));
        }

        protected void Apply(CartCreatedEvent @event)
        {
            this.Id = @event.CartId;
        }

        public Money CalculateTotal()
        {
            double running_total = 0;
            foreach (var cartItem in _lines)
            {
                running_total += cartItem.Total;
            }
            return running_total;
        }
    }
}