using System;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.Facebook.Authentication.Commands;
using LifeMap.Facebook.Authentication.Events;

namespace LifeMap.Facebook.Membership.ACL
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

        public void HandleRegistrationSubmitted()
        {
            base.Dispatch(new CreateFacebookLoginCommand(Id, _facebookId));
        }
    }
}
