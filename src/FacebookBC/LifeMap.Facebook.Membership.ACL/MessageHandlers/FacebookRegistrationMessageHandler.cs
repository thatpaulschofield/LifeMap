using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Facebook.Authentication.Events;
using LifeMap.Facebook.Membership.ACL;
using LifeMap.Membership.Events;
using LifeMap.Membership.Messages.Events;
using NServiceBus;

namespace LifeMap.Facebook.Authentication.MessageHandlers
{
    public class FacebookRegistrationMessageHandler : IHandleMessages<FacebookUserAuthenticatedForRegistrationEvent>
        , IHandleMessages<RegistrationSubmittedEvent>
    {
        private readonly ISagaRepository _repository;

        public FacebookRegistrationMessageHandler(ISagaRepository sagaRepository)
        {
            _repository = sagaRepository;
        }

        public void Handle(FacebookUserAuthenticatedForRegistrationEvent message)
        {
            var saga = _repository.GetById<FacebookRegistrationSaga>(message.RegistrationId);
            saga.Handle(message.RegistrationId, message.FacebookId);
            _repository.Save(saga, Guid.NewGuid(), h => { });
        }

        public void Handle(RegistrationSubmittedEvent message)
        {
            var saga = _repository.GetById<FacebookRegistrationSaga>(message.RegistrationId);
            saga.HandleRegistrationSubmitted();

        }
    }
}
