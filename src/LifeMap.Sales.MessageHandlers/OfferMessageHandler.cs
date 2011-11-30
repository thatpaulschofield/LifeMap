using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Common.Domain.SubscriptionsSubdomain;
using LifeMap.Sales.Commands;
using NServiceBus;

namespace LifeMap.Sales.MessageHandlers
{
    public class OfferMessageHandler : IHandleMessages<CreateOfferCommand>
    {
        private readonly IRepository _repository;

        public OfferMessageHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateOfferCommand message)
        {
            var offer = new Offer(message.Id, message.ProductId, new DateRange(message.ValidFrom, message.ValidTo),
                                  new Term(message.DurationInDays), message.Price);
            _repository.Save(offer, Guid.NewGuid());
        }
    }
}
