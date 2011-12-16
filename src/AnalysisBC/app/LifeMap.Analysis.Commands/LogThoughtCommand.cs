using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Analysis.Commands
{
    public class LogThoughtCommand : MessageBase
    {
        public Guid ThoughtId { get; set; }
        public string Content { get; set; }

        public DateTime Time { get; set; }
    }
}
