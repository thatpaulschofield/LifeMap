using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Common.Domain.SubscriptionsSubdomain;
using LifeMap.Membership.Events;

namespace LifeMap.Membership
{
    public class Member : AggregateBase
    {
        private IList<Subscription> _subscriptions = new List<Subscription>();

        private Member()
        {
            base.Register<MemberCreatedEvent>(Apply);
            base.Register<MemberSubscribedEvent>(Apply);
        }

        public Member(Guid memberId) : this()
        {
            base.RaiseEvent(new MemberCreatedEvent { MemberId = memberId });
        }

        public void SubscriptionWasPurchased(Guid memberId, Guid productId, int termInDays)
        {
            var beginDate = DateTime.Today;
            var endDate = beginDate.AddDays(termInDays);
            base.RaiseEvent(new MemberSubscribedEvent{ BeginDate = beginDate, EndDate = endDate, MemberId = this.Id, ProductId = productId});
        }

        protected void Apply(MemberCreatedEvent @event)
        {
            this.Id = @event.MemberId;
        }

        protected void Apply(MemberSubscribedEvent @event)
        {
            _subscriptions.Add(new Subscription(@event.ProductId, new DateRange(@event.BeginDate, @event.EndDate)));
        }
    }
}
