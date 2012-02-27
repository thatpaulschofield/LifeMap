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
using NServiceBus;
using Stateless;

namespace LifeMap.Membership.RegistrationProcess
{
    public class EmailConfirmationProcess : SagaBase<object>
    {
        private Guid _registrationId;
        private string _emailAddress;
        private bool _confirmed;
        private StateMachine<RegistrationStates, RegistrationTriggers> _stateMachine;
        private RegistrationStates _state = RegistrationStates.AwaitingConfirmation;

        public EmailConfirmationProcess()
        {
            _stateMachine = new StateMachine<RegistrationStates, RegistrationTriggers>(() => _state, state => _state = state);
            _stateMachine.Configure(RegistrationStates.AwaitingConfirmation).Permit(RegistrationTriggers.ConfirmationReceived,
                                                                   RegistrationStates.Success);
            
            Register<EmailConfirmationProcessStartedEvent>(Apply);
            Register<EmailAddressConfirmedEvent>(Apply);

        }

        public void Start(StartEmailConfirmationProcessCommand command)
        {
            var @event = EmailConfirmationProcessStartedEvent.Create(command.Id, command.RegistrationId, command.EmailAddress);
            base.Transition(@event);
            base.Dispatch(@event);
            var sendEmailCommand = SendEmailCommand.Create(command.EmailAddress, "no-reply@lifemap.com", FormatBody(command.Id));
            base.Dispatch(sendEmailCommand);
        }

        private void Apply(EmailConfirmationProcessStartedEvent @event)
        {
            this.Id = @event.Id;
            _registrationId = @event.RegistrationId;
            _emailAddress = @event.EmailAddress;
            _stateMachine.Fire(RegistrationTriggers.ConfirmationReceived);
        }

        private void Apply(EmailAddressConfirmedEvent @event)
        {
            _confirmed = true;
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

        enum RegistrationStates
        {
            AwaitingConfirmation,
            Success
        }

        private enum RegistrationTriggers
        {
            ConfirmationReceived
        }
    }
}
