using System;
using CommonDomain.Persistence;
using LifeMap.Membership.Commands;
using LifeMap.Membership.RegistrationProcess;
using NServiceBus;

namespace LifeMap.Membership.MessageHandlers
{
    public class EmailConfirmationMessageHandler : IMessageHandler<StartEmailConfirmationProcessCommand>, IMessageHandler<ConfirmEmailAddressCommand>
    {
        private readonly ISagaRepository _repository;

        public EmailConfirmationMessageHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(StartEmailConfirmationProcessCommand command)
        {
            EmailConfirmationProcess confirmationProcess = _repository.GetById<EmailConfirmationProcess>(command.Id);
            confirmationProcess.Start(command);
            _repository.Save(confirmationProcess, Guid.NewGuid(), h => { });
        }

        public void Handle(ConfirmEmailAddressCommand command)
        {
            EmailConfirmationProcess confirmationProcess = _repository.GetById<EmailConfirmationProcess>(command.ConfirmationId);
            confirmationProcess.ConfirmEmailAddress();
            _repository.Save(confirmationProcess, Guid.NewGuid(), h => { });
        }
    }
}