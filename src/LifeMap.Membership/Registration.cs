using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;
using NServiceBus;

namespace LifeMap.Membership
{
    public class Registration : SagaBase<IMessage>
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private Guid _offerId;

        public Registration()
        {
            base.Register<RegistrationStartedEvent>(Apply);
        }

        public Registration(Guid id, string firstName, string lastName, string emailAddress) : this()
        {
            base.Transition(new RegistrationStartedEvent(id, firstName, lastName, emailAddress));
        }

        public void Apply(RegistrationStartedEvent @event)
        {
            base.Id = @event.Id;
            _firstName = @event.FirstName;
            _lastName = @event.LastName;
            _emailAddress = @event.EmailAddress;
        }

    }
}
