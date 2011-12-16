using System;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    public interface ISpecifyCanSubmitRegistration : IMessage
    {
        Guid RegistrationId { get; }
        bool CanSubmitRegistration { get; }
    }
}