using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    public interface ISpecifyCanSubmitRegistration : IMessage
    {
        Guid RegistrationId { get; }
        bool CanSubmitRegistration { get; }
    }
}