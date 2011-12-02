using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using LifeMap.Membership.Events;
using NServiceBus;
using Raven.Client;

namespace LifeMap.Membership.ViewModels
{
    public class RegistrationMessageHandler : IHandleMessages<RegistrationStartedEvent>, IHandleMessages<LoginEnteredForRegistration>
    {
        private readonly IDocumentStore _documentStore;
        private readonly IDocumentSession _session;

        public RegistrationMessageHandler(IDocumentStore documentStore, IDocumentSession session)
        {
            _documentStore = documentStore;
            _session = session;
        }

        public void Handle(RegistrationStartedEvent message)
        {
            var vm = new RegistrationViewModel();
            Mapper.Map(message, vm);
            try
            {
                var session = _documentStore.OpenSession();
                session.Store(vm, vm.Id);
                session.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Handle(LoginEnteredForRegistration message)
        {
            var vm = _session.Load<RegistrationViewModel>(message.Id.ToString());
            Mapper.Map(message, vm);
            _session.SaveChanges();
        }
    }
}
