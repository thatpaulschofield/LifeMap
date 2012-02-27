using System;

namespace LifeMap.Membership.Events
{
    public interface ISpecifyCanSubmitRegistration
    {
        Guid RegistrationId { get; }
        bool CanSubmitRegistration { get; }
    }
}