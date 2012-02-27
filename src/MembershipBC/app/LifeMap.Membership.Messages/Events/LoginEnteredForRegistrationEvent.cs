using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class LoginEnteredForRegistrationEvent //: MessageBase, ISpecifyCanSubmitRegistration
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

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid LoginId { get; set; }

        [DataMember]
        public bool CanSubmitRegistration { get; set; }
    }
}
