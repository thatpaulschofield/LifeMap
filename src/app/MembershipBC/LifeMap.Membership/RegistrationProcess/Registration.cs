using System;
using CommonDomain.Core;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;
using NServiceBus;
using Stateless;

namespace LifeMap.Membership.RegistrationProcess
{
    public class Registration : SagaBase<IMessage>
    {
        private Guid _offerId;
        private RegistrationCreditCard _ccInfo;
        private RegistrationLogin _login;
        private RegistrationUser _user;
        private readonly StateMachine<RegistrationStates, RegistrationTriggers> _stateMachine;
        private RegistrationStates _state = RegistrationStates.New;

        public Registration()
        {
            base.Register<RegistrationStartedEvent>(Apply);
            base.Register<LoginEnteredForRegistration>(Apply);
            base.Register<CreditCardInformationEnteredForRegistration>(Apply);

            _stateMachine = new StateMachine<RegistrationStates, RegistrationTriggers>(() => _state, state => _state = state);
            
            _stateMachine.Configure(RegistrationStates.New).Permit(RegistrationTriggers.RegistrationStarted,
                                                                   RegistrationStates.GatheringInfo);

            _stateMachine.Configure(RegistrationStates.GatheringInfo)
                .PermitDynamic(RegistrationTriggers.CreditCardInfoEntered, CalculateStateAfterInfoGathered)
                .PermitDynamic(RegistrationTriggers.LoginInfoEntered, CalculateStateAfterInfoGathered)
                .PermitDynamic(RegistrationTriggers.OfferSelected, CalculateStateAfterInfoGathered);

            _stateMachine.Configure(RegistrationStates.ReadyForSubmission)
                .PermitIf(RegistrationTriggers.SubmissionRequested, RegistrationStates.Submitted, () => CanSubmit);

            _state = RegistrationStates.New;
        }

        public void StartRegistration(StartRegistrationCommand command) 
        {
            base.Transition(new RegistrationStartedEvent(command.Id, command.FirstName, command.LastName, command.EmailAddress));
        }

        public void LoginEntered(EnterLoginForRegistrationCommand command)
        {
            base.Transition(new LoginEnteredForRegistration(base.Id, command.UserName, command.Password));
        }
        
        public void CreditCardInformationEntered(CreditCardInformationEnteredForRegistration @event)
        {
            base.Transition(@event);
        }

        public void SelectOffer(SelectOfferCommand command)
        {
            base.Transition(new OfferSelectedForRegistration(base.Id, command.OfferId));
        }

        public void Submit(SubmitRegistrationCommand command)
        {
            _stateMachine.Fire(RegistrationTriggers.SubmissionRequested);
        }

        private void Apply(CreditCardInformationEnteredForRegistration @event)
        {
            _ccInfo = new RegistrationCreditCard(@event.NameOnCard, @event.CardNumber, @event.CvvNumber,
                                                 @event.ExpirationDate);
            _stateMachine.Fire(RegistrationTriggers.CreditCardInfoEntered);
        }

        private void Apply(RegistrationStartedEvent @event)
        {
            base.Id = @event.Id;
            _user = new RegistrationUser(@event.FirstName, @event.LastName, @event.EmailAddress);
            _stateMachine.Fire(RegistrationTriggers.RegistrationStarted);
            Dispatch(@event);
        }

        private void Apply(LoginEnteredForRegistration @event)
        {
            _login = new RegistrationLogin(@event.UserName, @event.Password);
            _stateMachine.Fire(RegistrationTriggers.LoginInfoEntered);
            Dispatch(@event);
        }

        private void Apply(OfferSelectedForRegistration @event)
        {
            _offerId = @event.OfferId;
            _stateMachine.Fire(RegistrationTriggers.OfferSelected);
        }


        private RegistrationStates CalculateStateAfterInfoGathered()
        {
            return CanSubmit ? RegistrationStates.ReadyForSubmission : _stateMachine.State;
        }
        private bool CanSubmit
        {
            get { return _ccInfo != null && _login != null && _user != null && _offerId != null; }
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
            CreditCardInfoEntered,
            LoginCreated,
            CreditCardCharged,
            SubmissionRequested
        }
    }
}
