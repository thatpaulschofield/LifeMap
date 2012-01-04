using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Facebook.Authentication.Events;
using LifeMap.Membership.Messages.Commands;
using NServiceBus;

namespace LifeMap.Facebook.Membership.ACL.MessageHandlers
{
    public class RegistrationMessageHandler : IHandleMessages<FacebookUserAuthenticatedForRegistrationEvent>
    {
        private readonly IBus _bus;

        public RegistrationMessageHandler(IBus bus)
        {
            _bus = bus;
        }
        public void Handle(FacebookUserAuthenticatedForRegistrationEvent message)
        {
           //_bus.Send(new SelectLoginForRegistrationCommand(message.RegistrationId, message.)) 
        }
    }
}
