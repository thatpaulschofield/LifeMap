using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.EmailGateway.Events
{
    [DataContract, Serializable]
    public class EmailSentEvent : IEvent //: MessageBase
    {
    }
}
