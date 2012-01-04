using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Facebook.Authentication.Events;

namespace LifeMap.Facebook.Authentication
{
    public class FacebookLogin : AggregateBase
    {
        private int _facebookId;

        public FacebookLogin()
        {
            Register<FacebookLoginCreatedEvent>(Apply);
        }

        public void Register(Guid loginId, int facebookId)
        {
            base.RaiseEvent(new FacebookLoginCreatedEvent(loginId, facebookId));
        }

        private void Apply(FacebookLoginCreatedEvent @event)
        {
            base.Id = @event.LoginId;
            _facebookId = @event.FacebookId;
        }
    }
}
