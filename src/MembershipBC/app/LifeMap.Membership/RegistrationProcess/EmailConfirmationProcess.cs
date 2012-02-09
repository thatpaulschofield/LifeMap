using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.EmailGateway.Commands;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;
using LifeMap.Membership.Messages.Events;

namespace LifeMap.Membership.RegistrationProcess
{
    public class EmailConfirmationProcess : SagaBase<IMessage>
    {
        private Guid _registrationId;
        private string _emailAddress;

        public EmailConfirmationProcess()
        {
            Register<EmailConfirmationProcessStartedEvent>(Apply);
            Register<EmailAddressConfirmedEvent>(Apply);
        }

        public void Start(StartEmailConfirmationProcessCommand command)
        {
            var @event = EmailConfirmationProcessStartedEvent.Create(command.Id, command.RegistrationId, command.EmailAddress);
            base.Transition(@event);
            var sendEmailCommand = SendEmailCommand.Create(command.EmailAddress, "no-reply@lifemap.com", FormatBody(command.Id));
            base.Dispatch(sendEmailCommand);
        }

        private void Apply(EmailConfirmationProcessStartedEvent @event)
        {
            this.Id = @event.Id;
            _registrationId = @event.RegistrationId;
            _emailAddress = @event.EmailAddress;
        }

        private void Apply(EmailAddressConfirmedEvent command)
        {

        }

        private string FormatBody(Guid processId)
        {
            return String.Format("http://localhost/LifeMap.Web/#membership/registration/{0}/confirmEmail/{1}", _registrationId, processId);
        }

        public void ConfirmEmailAddress()
        {
            var command = ConfirmRegisteredEmailAddressCommand.Create(_registrationId, Id, _emailAddress);
            base.Dispatch(command);

            var @event = EmailAddressConfirmedEvent.Create(Id, _registrationId, _emailAddress);
            base.Transition(@event);
        }
    }
}
