using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class LoginEnteredForRegistration : MessageBase
    {
        public LoginEnteredForRegistration()
        {
        }

        public LoginEnteredForRegistration(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
