﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Membership.Commands;
using LifeMap.Membership.RegistrationProcess;
using NServiceBus;

namespace LifeMap.Membership.MessageHandlers
{
    public class RegistrationMessageHandler : IHandleMessages<StartRegistrationCommand>, IHandleMessages<EnterLoginForRegistrationCommand>,
        IHandleMessages<EnterCreditCardInformationForRegistrationCommand>
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
            try
            {
                _repository.Save(registration, Guid.NewGuid(), h => { });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Handle(EnterLoginForRegistrationCommand command)
        {
            Registration registration = _repository.GetById<Registration>(command.RegistrationId);
            registration.LoginEntered(command);
            try
            {
                _repository.Save(registration, Guid.NewGuid(), h => { });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Handle(EnterCreditCardInformationForRegistrationCommand command)
        {
            Registration registration = _repository.GetById<Registration>(command.RegistrationId);
            registration.EnterCreditCardInformation(command);
            try
            {
                _repository.Save(registration, Guid.NewGuid(), h => { });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
