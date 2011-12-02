using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Security.Commands;
using LifeMap.Security.Events;
using NServiceBus;

namespace LifeMap.Security
{
    public class SignUp : SagaBase<IMessage>
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _password;

        public SignUp()
        {
            Register<SignupBegunEvent>(Apply);
        }

        public void Begin(Guid correlationId, string firstName, string lastName, string emailAddress, string password)
        {
            base.Dispatch(new SignupBegunEvent { Id = correlationId, FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, Password = password });
        }

        public void Apply(SignupBegunEvent @event)
        {
            base.Id = @event.Id;
            _firstName = @event.FirstName;
            _lastName = @event.LastName;
            _emailAddress = @event.EmailAddress;
            _password = @event.Password;

            // TODO: verify email address before creating account
            base.Dispatch(new CreateLoginCommand(this.Id, _emailAddress, _password));
        }
    }
}
