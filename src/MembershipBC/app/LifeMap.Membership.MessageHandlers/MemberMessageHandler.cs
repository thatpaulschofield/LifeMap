using System;
using CommonDomain.Persistence;
using LifeMap.Sales.Events;
using LifeMap.Security.Events;
using NServiceBus;

namespace LifeMap.Membership.MessageHandlers
{
    public class MemberMessageHandler : IHandleMessages<LoginCreatedEvent>, IHandleMessages<SubscriptionPurchasedEvent>
    {
        private IRepository _repository;

        public MemberMessageHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(LoginCreatedEvent @event)
        {
            var member = new Member(@event.Id, @event.LoginId);
            _repository.Save(member, Guid.NewGuid());
        }

        public void Handle(SubscriptionPurchasedEvent @event)
        {
            var member = _repository.GetById<Member>(@event.LoginId);
            member.SubscriptionWasPurchased(@event.Id, @event.ProductId, @event.TermInDays);
        }
    }
}