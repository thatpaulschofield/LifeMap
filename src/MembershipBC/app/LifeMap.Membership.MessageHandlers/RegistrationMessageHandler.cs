using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Messages.Commands;
using LifeMap.Membership.Messages.Events;
using LifeMap.Membership.RegistrationProcess;
using NServiceBus;

namespace LifeMap.Membership.MessageHandlers
{
    public class RegistrationMessageHandler : IMessageHandler<StartRegistrationCommand>,
                                              IMessageHandler<SelectLoginForRegistrationCommand>,
                                              IMessageHandler<EnterCreditCardInformationForRegistrationCommand>,
                                              IMessageHandler<ConfirmRegisteredEmailAddressCommand>
    {
        private readonly ISagaRepository _repository;

        public RegistrationMessageHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(StartRegistrationCommand command)
        {
            Registration registration = _repository.GetById<Registration>(command.RegistrationId);
            registration.StartRegistration(command);
            _repository.Save(registration, Guid.NewGuid(), h => { });
        }

        public void Handle(SelectLoginForRegistrationCommand command)
        {
            Registration registration = _repository.GetById<Registration>(command.RegistrationId);
            registration.LoginEntered(command);
            _repository.Save(registration, Guid.NewGuid(), h => { });
        }

        public void Handle(EnterCreditCardInformationForRegistrationCommand command)
        {
            Registration registration = _repository.GetById<Registration>(command.RegistrationId);
            registration.EnterCreditCardInformation(command);
            _repository.Save(registration, Guid.NewGuid(), h => { });
        }

        public void Handle(ConfirmRegisteredEmailAddressCommand command)
        {
            Registration registration = _repository.GetById<Registration>(command.RegistrationId);
            registration.ConfirmEmailAddress(command);
            _repository.Save(registration, Guid.NewGuid(), h => { });
        }
    }
}
