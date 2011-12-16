using System;
using LifeMap.Common.Domain;

namespace LifeMap.Facebook.Authentication.Events
{
    [Serializable]
    public class FacebookRegistrationBegunEvent : MessageBase
    {
        public FacebookRegistrationBegunEvent()
        {
        }

        public FacebookRegistrationBegunEvent(Guid registrationId, int facebookId)
        {
            RegistrationId = registrationId;
            FacebookId = facebookId;
        }

        public Guid RegistrationId { get; set; }
        public int FacebookId { get; set; }
    }
}