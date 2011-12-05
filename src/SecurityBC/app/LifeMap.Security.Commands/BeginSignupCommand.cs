using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Security.Commands
{
    [Serializable]
    public class BeginSignupCommand : MessageBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }       
    }
}