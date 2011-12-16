using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Facebook.Authentication.Events
{
    [Serializable]
    public class FacebookUserAuthenticatedForRegistrationEvent : MessageBase
    {
        public FacebookUserAuthenticatedForRegistrationEvent()
        {
            Id = Guid.NewGuid();
        }

        public FacebookUserAuthenticatedForRegistrationEvent(string code) : this()
        {
            Code = code;
        }

        public FacebookUserAuthenticatedForRegistrationEvent(string registrationId, int facebookId, string code, string accessToken)
        {
            RegistrationId = new Guid(registrationId);
            FacebookId = facebookId;
            Code = code;
            AccessToken = accessToken;
        }

        public Guid RegistrationId { get; set; }
        public int FacebookId { get; set; }
        public string AccessToken { get; set; }
        public string Code { get; set; }
    }
}
