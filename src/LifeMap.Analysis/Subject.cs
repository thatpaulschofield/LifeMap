using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Analysis.Events;

namespace LifeMap.Analysis
{
    public class Subject : AggregateBase
    {
        private Subject()
        {
            base.Register<SubjectCreatedEvent>(Apply);
        }

        public Subject(Guid correlationId, Guid subjectId) : this()
        {
            base.RaiseEvent(new SubjectCreatedEvent(correlationId, subjectId));
        }

        private void Apply(SubjectCreatedEvent @event)
        {
            base.Id = @event.Id;
        }
    }
}
