using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;
using NServiceBus;

namespace LifeMap.Membership
{
    public class Registration : SagaBase<IMessage>
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private Guid _offerId;
        private string _userName;
        private string _password;
        private string _nameOnCard;
        private string _cardNumber;
        private string _cvvNumber;
        private DateTime _expirationDate;

        public Registration()
        {
            base.Register<RegistrationStartedEvent>(Apply);
            base.Register<LoginEnteredForRegistration>(Apply);
            base.Register<CreditCardInformationEnteredForRegistration>(Apply);
        }

        public Registration(Guid id, string firstName, string lastName, string emailAddress) : this()
        {
            base.Transition(new RegistrationStartedEvent(id, firstName, lastName, emailAddress));
        }

        public void LoginEntered(LoginEnteredForRegistration @event)
        {
            base.Transition(@event);
        }
        
        public void CreditCardInformationEntered(CreditCardInformationEnteredForRegistration @event)
        {
            base.Transition(@event);
        }

        private void Apply(CreditCardInformationEnteredForRegistration @event)
        {
            _nameOnCard = @event.NameOnCard;
            _cardNumber = @event.CardNumber;
            _cvvNumber = @event.CvvNumber;
            _expirationDate = @event.ExpirationDate;
        }

        private void Apply(RegistrationStartedEvent @event)
        {
            base.Id = @event.Id;
            _firstName = @event.FirstName;
            _lastName = @event.LastName;
            _emailAddress = @event.EmailAddress;
        }

        private void Apply(LoginEnteredForRegistration @event)
        {
            _userName = @event.UserName;
            _password = @event.Password;
        }
    }
}
