using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using LifeMap.Sales.Events;
using NServiceBus;
using Raven.Client;

namespace LifeMap.Sales.ViewModels.MessageHandlers
{
    public class OfferMessageHandler : IHandleMessages<OfferCreatedEvent>
    {
        private readonly IDocumentStore _documentStore;

        public OfferMessageHandler(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Handle(OfferCreatedEvent @event)
        {
            var vm = new OfferViewModel();
            Mapper.Map(@event, vm);
            IDocumentSession session;
            using (session = _documentStore.OpenSession())
            {
                session.Store(vm);
                session.SaveChanges();
            }
        }
    }
}
