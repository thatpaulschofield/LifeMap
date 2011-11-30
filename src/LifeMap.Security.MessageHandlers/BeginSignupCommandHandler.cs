using System;
using CommonDomain.Persistence;
using LifeMap.Security.Commands;
using NServiceBus;

namespace LifeMap.Security.MessageHandlers
{
    public class BeginSignupCommandHandler : IHandleMessages<BeginSignupCommand>
    {
        private readonly ISagaRepository _repository;

        public BeginSignupCommandHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(BeginSignupCommand command)
        {
            var signup = _repository.GetById<SignUp>(command.Id);
            signup.Begin(command.Id, command.FirstName, command.LastName, command.EmailAddress, command.Password);
        }
    }
}