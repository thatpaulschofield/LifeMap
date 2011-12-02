using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Security.Events
{
    [Serializable]
    public class LoginCreatedEvent : MessageBase
    {
        public LoginCreatedEvent()
        {
        }

        public LoginCreatedEvent(Guid correlationId, Guid loginId, string userName, string password)
        {
            base.Id = correlationId;
            LoginId = loginId;
            UserName = userName;
            Password = password;
        }

        public Guid LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
