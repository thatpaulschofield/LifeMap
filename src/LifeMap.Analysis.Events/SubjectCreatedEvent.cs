using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Analysis.Events
{
    [Serializable]
    public class SubjectCreatedEvent : MessageBase
    {
        public SubjectCreatedEvent()
        {
        }

        public SubjectCreatedEvent(Guid correlationId, Guid subjectId)
        {
            base.Id = correlationId;
            SubjectId = subjectId;
        }

        public Guid SubjectId { get; set; }
    }
}
