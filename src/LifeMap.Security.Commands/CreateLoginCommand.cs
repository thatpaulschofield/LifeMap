using System;
using LifeMap.Common.Domain;

namespace LifeMap.Security.Commands
{
    [Serializable]
    public class CreateLoginCommand : MessageBase
    {
        public CreateLoginCommand()
        {
        }

        public CreateLoginCommand(Guid Id, string userName, string password)
        {
            base.Id = Id;
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}