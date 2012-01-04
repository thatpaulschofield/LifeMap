using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.Membership.Events;
using LifeMap.Sales.Commands;

namespace Lifemap.Membership.Sales.ACL.Model
{
    public class RegistrationCart : SagaBase<IMessage>
    {
        public RegistrationCart()
        {
            base.Register<RegistrationStartedEvent>(Apply);
        }

        public void Handle(RegistrationStartedEvent @event)
        {
            base.Transition(@event);
        }

        private void Apply(RegistrationStartedEvent @event)
        {
            base.Dispatch(new CreateCartCommand(@event.RegistrationId));
        }
    }
}
