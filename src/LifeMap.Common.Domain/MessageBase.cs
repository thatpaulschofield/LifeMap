using System;
using NServiceBus;

namespace LifeMap.Common.Domain
{
    public class MessageBase : IMessage
    {
        public Guid Id { get; set; }
    }
}