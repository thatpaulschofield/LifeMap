using System;
using System.Collections.Generic;
using CommonDomain.Core;
using LifeMap.Sales.Events;
using NServiceBus;

namespace LifeMap.Sales.CartAggregate
{
    public class ShoppingCart : SagaBase<IMessage>
    {
        private List<CartItem> _lines = new List<CartItem>();

        public ShoppingCart()
        {
            base.Register<OfferAddedToShoppingCartEvent>(Transition);
        }

        public void AddOffer(Offer offer)
        {
            base.Transition(new OfferAddedToShoppingCartEvent{OfferId = offer.Id, Total = offer.GetPrice()});
        }

        protected void Transition(OfferAddedToShoppingCartEvent @event)
        {
            _lines.Add(new CartItem(@event.OfferId, @event.Total));
        }

    }
}