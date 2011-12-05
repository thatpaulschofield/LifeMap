using System;
using NServiceBus;

namespace LifeMap.Common.Domain
{
    public abstract class MessageBase : IMessage
    {
        protected MessageBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}