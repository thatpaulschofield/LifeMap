using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Facebook.Authentication.Commands;
using NServiceBus;

namespace LifeMap.Facebook.Authentication.MessageHandlers
{
    class FacebookLoginMessageHandler : IHandleMessages<CreateFacebookLoginCommand>
    {
        public FacebookLoginMessageHandler()
        {
            
        }

        public void Handle(CreateFacebookLoginCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
