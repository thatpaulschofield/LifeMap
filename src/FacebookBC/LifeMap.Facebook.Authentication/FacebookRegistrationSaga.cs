using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Facebook.Authentication.Events;
using NServiceBus;

namespace LifeMap.Facebook.Authentication
{
    public class FacebookRegistrationSaga : SagaBase<IMessage>
    {
        private int _facebookId;
        private Guid _registrationId;

        public FacebookRegistrationSaga()
        {
            Register<FacebookRegistrationBegunEvent>(Apply);
        }

        public void Handle(Guid registrationId, int facebookId)
        {
            base.Transition(new FacebookRegistrationBegunEvent(registrationId, facebookId));
        }

        private void Apply(FacebookRegistrationBegunEvent @event)
        {
            Id = @event.RegistrationId;
            _registrationId = @event.RegistrationId;
            _facebookId = @event.FacebookId;
        }
    }
}
