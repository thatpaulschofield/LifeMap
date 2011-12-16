using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using Facebook;
using LifeMap.Facebook.Authentication.Events;
using NServiceBus;

namespace LifeMap.Facebook.MessageHandlers
{
    public class FeedImportSagaMessageHandler : IHandleMessages<FacebookUserAuthenticatedForRegistrationEvent>
    {
        private readonly ISagaRepository _repository;
        private readonly IFacebookApplication _facebookApplication;

        public FeedImportSagaMessageHandler(ISagaRepository repository, IFacebookApplication facebookApplication)
        {
            _repository = repository;
            _facebookApplication = facebookApplication;
        }

        public void Handle(FacebookUserAuthenticatedForRegistrationEvent message)
        {
            var saga = _repository.GetById<ImportPostsSaga>(message.Id);
            saga.HandleUserAuthenticated(message.Id, message.AccessToken, message.Code, _facebookApplication);
        }
    }

    //public class
}
