﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Security.Events
{
    [Serializable]
    public class LoginCreatedEvent : MessageBase
    {
        public LoginCreatedEvent()
        {
        }

        public LoginCreatedEvent(Guid loginId, string userName, string password)
        {
            LoginId = loginId;
            UserName = userName;
            Password = password;
        }

        public Guid LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
