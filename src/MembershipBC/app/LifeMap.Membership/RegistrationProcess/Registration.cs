using System;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;
using LifeMap.Membership.Messages.Commands;
using LifeMap.Membership.Messages.Events;
using Stateless;

namespace LifeMap.Membership.RegistrationProcess
{
    public class Registration : SagaBase<object>
    {
        private Guid? _offerId;
        private RegistrationCreditCard _ccInfo;
        private RegistrationLogin _login;
        private RegistrationUser _user;
        private readonly StateMachine<RegistrationStates, RegistrationTriggers> _stateMachine;
        private RegistrationStates _state = RegistrationStates.New;
        private string _emailAddress;

        public Registration()
        {
            _stateMachine = new StateMachine<RegistrationStates, RegistrationTriggers>(() => _state, state => _state = state);

            _stateMachine.Configure(RegistrationStates.New).Permit(RegistrationTriggers.RegistrationStarted,
                                                                   RegistrationStates.GatheringInfo);

            _stateMachine.Configure(RegistrationStates.GatheringInfo)
                .PermitDynamic(RegistrationTriggers.EmailAddressConfirmed, CalculateStateAfterInfoGathered)
                .PermitDynamic(RegistrationTriggers.CreditCardInfoEntered, CalculateStateAfterInfoGathered)
                .PermitDynamic(RegistrationTriggers.LoginInfoEntered, CalculateStateAfterInfoGathered)
                .PermitDynamic(RegistrationTriggers.OfferSelected, CalculateStateAfterInfoGathered);

            _stateMachine.Configure(RegistrationStates.ReadyForSubmission)
                .PermitDynamic(RegistrationTriggers.EmailAddressConfirmed, CalculateStateAfterInfoGathered)
                .PermitIf(RegistrationTriggers.SubmissionRequested, RegistrationStates.Submitted, () => CanSubmit);

            _stateMachine.Configure(RegistrationStates.Submitted)
                .OnEntry(this.OnSubmitted);
            _state = RegistrationStates.New;

            base.Register<RegistrationStartedEvent>(Apply);
            base.Register<LoginEnteredForRegistrationEvent>(Apply);
            base.Register<CreditCardInformationEnteredForRegistrationEvent>(Apply);
            base.Register<RegisteredEmailAddressConfirmed>(Apply);
        }

        public void StartRegistration(StartRegistrationCommand command) 
        {
            base.Transition(new RegistrationStartedEvent(command.RegistrationId, command.FirstName, command.LastName, command.EmailAddress, command.Password));
            this.BeginEmailConfirmationProcess(command.EmailAddress);
        }

        private void BeginEmailConfirmationProcess(string emailAddress)
        {
            base.Dispatch(StartEmailConfirmationProcessCommand.Create(emailAddress, Id));
        }

        public void LoginEntered(SelectLoginForRegistrationCommand command)
        {
            base.Transition(new LoginEnteredForRegistrationEvent(command.RegistrationId, command.LoginId, CanSubmit));
        }

        public void EnterCreditCardInformation(EnterCreditCardInformationForRegistrationCommand command)
        {
            base.Transition(new CreditCardInformationEnteredForRegistrationEvent{ Id =command.RegistrationId, RegistrationId = command.RegistrationId, CardNumber = command.CardNumber, CvvNumber = command.CvvNumber, ExpirationDate = command.ExpirationDate, NameOnCard = command.NameOnCard, CanSubmitRegistration = CanSubmit});
        }

        public void SelectOffer(SelectOfferCommand command)
        {
            base.Transition(new OfferSelectedForRegistrationEvent(command.RegistrationId, command.OfferId, CanSubmit));
        }

        public void Submit(SubmitRegistrationCommand command)
        {
            base.Transition(new RegistrationSubmittedEvent
                                {
                                    Id = command.Id,
                                    RegistrationId = this.Id,
                                    CardNumber = _ccInfo.CardNumber,
                                    CvvNumber = _ccInfo.CvvNumber,
                                    ExpirationDate = _ccInfo.ExpirationDate,
                                    NameOnCard = _ccInfo.NameOnCard,

                                    FirstName = _user.FirstName,
                                    LastName = _user.LastName,
                                    EmailAddress = _user.EmailAddress
                                });
        }

        public void ConfirmEmailAddress(ConfirmRegisteredEmailAddressCommand command)
        {
            var @event = RegisteredEmailAddressConfirmed.Create(command.Id, this.Id, command.EmailAddress);
            base.Transition(@event);
            base.Dispatch(@event);
        }

        #region Apply Methods

        private void Apply(RegisteredEmailAddressConfirmed @event)
        {
            _emailAddress = @event.EmailAddress;
            _stateMachine.Fire(RegistrationTriggers.EmailAddressConfirmed);
        }

        private void Apply(CreditCardInformationEnteredForRegistrationEvent @event)
        {
            _ccInfo = new RegistrationCreditCard(@event.NameOnCard, @event.CardNumber, @event.CvvNumber,
                                                 @event.ExpirationDate);
            _stateMachine.Fire(RegistrationTriggers.CreditCardInfoEntered);
        }

        private void Apply(RegistrationStartedEvent @event)
        {
            base.Id = @event.RegistrationId;
            _user = new RegistrationUser(@event.FirstName, @event.LastName, @event.EmailAddress);
            _stateMachine.Fire(RegistrationTriggers.RegistrationStarted);
        }

        private void Apply(LoginEnteredForRegistrationEvent @event)
        {
            _login = new RegistrationLogin(@event.LoginId);
            _stateMachine.Fire(RegistrationTriggers.LoginInfoEntered);
        }

        private void Apply(OfferSelectedForRegistrationEvent @event)
        {
            _offerId = @event.OfferId;
            _stateMachine.Fire(RegistrationTriggers.OfferSelected);
        }
        #endregion

        private RegistrationStates CalculateStateAfterInfoGathered()
        {
            return //_stateMachine.State;
            CanSubmit ? RegistrationStates.ReadyForSubmission : _stateMachine.State;
        }

        private bool CanSubmit
        {
            get { return !String.IsNullOrEmpty(_emailAddress); }
        }

        private void OnSubmitted()
        {
        }

        public enum RegistrationStates
        {
            New,
            GatheringInfo,
            ReadyForSubmission,
            Submitted,
            Complete
        }

        public enum RegistrationTriggers
        {
            RegistrationStarted,
            OfferSelected,
            LoginInfoEntered,
            EmailAddressConfirmed,
            CreditCardInfoEntered,
            LoginCreated,
            CreditCardCharged,
            SubmissionRequested
        }
    }
}
