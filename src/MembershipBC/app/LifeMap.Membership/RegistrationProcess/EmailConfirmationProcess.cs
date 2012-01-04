using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.EmailGateway.Commands;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;

namespace LifeMap.Membership.RegistrationProcess
{
    public class EmailConfirmationProcess : SagaBase<IMessage>
    {
        public EmailConfirmationProcess()
        {
            Register<EmailConfirmationProcessStartedEvent>(Apply);
        }

        public void Start(StartEmailConfirmationProcessCommand command)
        {
            var @event = EmailConfirmationProcessStartedEvent.Create(command.Id);
            base.Transition(@event);
            var sendEmailCommand = SendEmailCommand.Create(command.EmailAddress, "no-reply@lifemap.com", FormatBody(command.Id));
            base.Dispatch(sendEmailCommand);
        }

        private void Apply(EmailConfirmationProcessStartedEvent obj)
        {
            
        }

        private string FormatBody(Guid processId)
        {
            return String.Format("http://localhost/LifeMap.Web/#membership/registration/confirmEmail/{0}", processId);
        }
    }
}
