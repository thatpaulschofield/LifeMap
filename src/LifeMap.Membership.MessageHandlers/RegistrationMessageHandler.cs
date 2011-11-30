using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Membership.Commands;
using NServiceBus;

namespace LifeMap.Membership.MessageHandlers
{
    public class RegistrationMessageHandler : IHandleMessages<StartRegistration>
    {
        private readonly ISagaRepository _repository;

        //public RegistrationMessageHandler()
        //{
        //}

        public RegistrationMessageHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(StartRegistration message)
        {
            Registration registration = new Registration(message.Id, message.FirstName, message.LastName, message.EmailAddress);
            try
            {
                _repository.Save(registration, message.Id, h => { });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
