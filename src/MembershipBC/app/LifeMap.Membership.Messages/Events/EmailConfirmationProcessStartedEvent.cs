using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class EmailConfirmationProcessStartedEvent : MessageBase
    {
        public static EmailConfirmationProcessStartedEvent Create(Guid id)
        {
            return new EmailConfirmationProcessStartedEvent
                       {
                           Id = id
                       };
        }
    }
}