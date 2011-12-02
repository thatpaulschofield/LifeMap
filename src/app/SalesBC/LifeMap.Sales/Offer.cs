using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Common.Domain.SubscriptionsSubdomain;
using LifeMap.Sales.Events;

namespace LifeMap.Sales
{
    public class Offer : AggregateBase
    {
        private Offer()
        {
            Register<OfferCreatedEvent>(Apply);
        }

        public Offer(Guid id, Guid productId, DateRange validity, Term term, Money price) : this()
        {
            base.RaiseEvent(new OfferCreatedEvent
                                {
                                    ProductId = productId,
                                    DurationInDays = term.DurationInDays,
                                    Id = id,
                                    ValidFrom = validity.From,
                                    ValidTo = validity.To,
                                    Price = price
                                });
        }

        protected void Apply(OfferCreatedEvent @event)
        {
            this.Id = @event.Id;
            _productId = @event.ProductId;
            _term = new Term(@event.DurationInDays);
            _validity = new DateRange(@event.ValidFrom, @event.ValidTo);
            _price = @event.Price;
        }

        private Guid _productId;
        private DateRange _validity;
        private Term _term;
        private Money _price;

        public Money GetPrice()
        {
            return _price;
        }
    }
}
