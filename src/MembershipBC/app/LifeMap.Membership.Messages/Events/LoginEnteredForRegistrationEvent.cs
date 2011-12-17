using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class LoginEnteredForRegistrationEvent : MessageBase, ISpecifyCanSubmitRegistration
    {
        public LoginEnteredForRegistrationEvent()
        {
        }

        public LoginEnteredForRegistrationEvent(Guid registrationId, Guid loginId, bool canSubmit)
        {
            Id = registrationId;
            RegistrationId = registrationId;
            LoginId = loginId;
            CanSubmitRegistration = canSubmit;
        }

        public Guid RegistrationId { get; set; }
        public Guid LoginId { get; set; }
        public bool CanSubmitRegistration { get; set; }
    }
}
