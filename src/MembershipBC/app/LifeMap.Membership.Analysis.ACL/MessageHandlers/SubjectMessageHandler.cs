using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Analysis.Commands;
using LifeMap.Membership.Events;
using NServiceBus;

namespace LifeMap.Membership.Analysis.ACL.MessageHandlers
{
    public class SubjectMessageHandler : IHandleMessages<RegistrationSubmittedEvent>
    {
        private readonly IBus _bus;

        public SubjectMessageHandler(IBus bus)
        {
            _bus = bus;
        }
        public void Handle(RegistrationSubmittedEvent @event)
        {
            _bus.Send(new CreateSubjectCommand(@event.Id));
        }
    }
}
