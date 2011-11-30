using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Analysis.Commands
{
    [Serializable]
    public class CreateSubjectCommand : MessageBase
    {
        public CreateSubjectCommand()
        {
        }

        public CreateSubjectCommand(Guid subjectId)
        {
            base.Id = Guid.NewGuid();
            SubjectId = subjectId;
        }

        public Guid SubjectId { get; set; }
    }
}
