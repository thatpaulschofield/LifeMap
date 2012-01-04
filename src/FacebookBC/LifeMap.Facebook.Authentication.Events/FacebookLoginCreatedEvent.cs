using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Facebook.Authentication.Events
{
    [Serializable]
    public class FacebookLoginCreatedEvent : MessageBase
    {
        public FacebookLoginCreatedEvent()
        {
        }

        public FacebookLoginCreatedEvent(Guid loginId, int facebookId)
        {
            LoginId = loginId;
            FacebookId = facebookId;
        }

        public Guid LoginId { get; set; }
        public int FacebookId { get; set; }
    }
}
