using System;
using CommonDomain.Persistence;
using LifeMap.Sales.Commands;
using NServiceBus;
using ShoppingCart = LifeMap.Sales.CartAggregate.ShoppingCart;

namespace LifeMap.Sales.MessageHandlers
{
    public class ShoppingCartMessageHandler : IHandleMessages<AddOfferToShoppingCartCommand>
    {
        private readonly ISagaRepository _sagaRepository;
        private readonly IRepository _repository;

        public ShoppingCartMessageHandler(ISagaRepository sagaRepository, IRepository repository)
        {
            _sagaRepository = sagaRepository;
            _repository = repository;
        }

        public void Handle(AddOfferToShoppingCartCommand message)
        {
            var offer = _repository.GetById<Offer>(message.OfferId);
            _sagaRepository.GetById<ShoppingCart>(message.OrderId)
                .AddOffer(offer);
        }
    }
}