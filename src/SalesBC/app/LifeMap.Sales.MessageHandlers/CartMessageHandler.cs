using System;
using CommonDomain.Persistence;
using LifeMap.Sales.CartAggregate;
using LifeMap.Sales.Commands;
using NServiceBus;

namespace LifeMap.Sales.MessageHandlers
{
    public class CartMessageHandler : IHandleMessages<CreateCartCommand>
    {
        private readonly ISagaRepository _repository;

        public CartMessageHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateCartCommand message)
        {
            var cart = _repository.GetById<ShoppingCart>(message.CartId);
            _repository.Save(cart, Guid.NewGuid(), x => { });
        }
    }
}