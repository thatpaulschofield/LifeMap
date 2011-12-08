using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using LifeMap.Common.Infrastructure.Denormalizers;
using LifeMap.Membership.Events;
using NServiceBus;
using Raven.Client;

namespace LifeMap.Membership.ViewModels
{
    public class RegistrationMessageHandler : IDenormalize<RegistrationViewModel>, 
        IHandleMessages<RegistrationStartedEvent>, 
        IHandleMessages<LoginEnteredForRegistrationEvent>,
        IHandleMessages<CreditCardInformationEnteredForRegistrationEvent>
    {
        private readonly IDocumentSession _session;

        public RegistrationMessageHandler(IDocumentSession session)
        {
            _session = session;
        }

        public void Handle(RegistrationStartedEvent message)
        {
            var vm = new RegistrationViewModel();
            Mapper.Map(message, vm);
            vm.CanAddCreditCardInfo = true;
            vm.CanAddLogin = true;
            try
            {
                _session.Store(vm, vm.Id);
                _session.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Handle(LoginEnteredForRegistrationEvent message)
        {
            var vm = _session.Load<RegistrationViewModel>("registrationviewmodels/" + message.RegistrationId);
            if (vm == null)
                throw new ArgumentException("RegistrationViewModel with id " + message.RegistrationId + " not found.");
            Mapper.Map(message, vm);
            _session.SaveChanges();
        }

        public void Handle(CreditCardInformationEnteredForRegistrationEvent message)
        {
            var vm = _session.Load<RegistrationViewModel>("registrationviewmodels/" + message.RegistrationId);
            if (vm == null)
                throw new ArgumentException("RegistrationViewModel with id " + message.RegistrationId + " not found.");
            Mapper.Map(message, vm);
            _session.SaveChanges();
        }
    }
}
