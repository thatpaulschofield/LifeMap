using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class RegistrationReadyForSubmissionEvent : MessageBase
    {
        
    }
}