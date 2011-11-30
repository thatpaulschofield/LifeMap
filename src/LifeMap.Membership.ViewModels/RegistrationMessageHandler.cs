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
    public class RegistrationMessageHandler : IHandleMessages<RegistrationStartedEvent>
    {
        private readonly IDocumentStore _documentStore;

        public RegistrationMessageHandler(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
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
    }
}
