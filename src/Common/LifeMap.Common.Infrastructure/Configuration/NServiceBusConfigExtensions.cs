using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace LifeMap.Common.Infrastructure.Configuration
{
    public static class NServiceBusConfigExtensions
    {
        public static Configure WithDefaultMessageSpecifications(this Configure configure)
        {
            return configure
                .DefiningCommandsAs(MessageSpecification.IsCommand)
                .DefiningEventsAs(MessageSpecification.IsEvent)
                .DefiningMessagesAs(MessageSpecification.IsMessage)
                ;
        }
    }
}
