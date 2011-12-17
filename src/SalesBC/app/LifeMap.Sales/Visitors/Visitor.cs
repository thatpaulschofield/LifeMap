using System.Collections.Generic;
using CommonDomain.Core;
using LifeMap.Common.Domain;
using LifeMap.Sales.Events;
using NServiceBus;

namespace LifeMap.Sales.Visitors
{
    public class Visitor : SagaBase<IMessage>
    {
        private List<PageVisit> _visits = new List<PageVisit>();

        public Visitor()
        {
            base.Register<VisitorVisitedPageEvent>(Transition);
        }

        public void Transition(VisitorVisitedPageEvent @event)
        {
            _visits.Add(new PageVisit {TimeOfVisit = @event.TimeOfVisit, Url = @event.PageUrl});
        }
    }
}
