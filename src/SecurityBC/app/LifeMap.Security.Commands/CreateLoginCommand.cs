using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Security.Commands
{
    [Serializable]
    public class CreateLoginCommand : MessageBase
    {
        public CreateLoginCommand()
        {
        }

        public CreateLoginCommand(Guid loginId, string userName, string password)
        {
            LoginId = loginId;
            UserName = userName;
            Password = password;
        }

        public Guid LoginId;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}