using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Membership.Events;
using Lifemap.Membership.Sales.ACL.Model;
using NServiceBus;

namespace Lifemap.Membership.Sales.ACL.MessageHandlers
{
    public class RegistrationCartMessageHandler : IHandleMessages<RegistrationStartedEvent>
    {
        private readonly ISagaRepository _repository;

        public RegistrationCartMessageHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RegistrationStartedEvent message)
        {
            var registrationCart = _repository.GetById<RegistrationCart>(message.RegistrationId);

        }
    }
}
