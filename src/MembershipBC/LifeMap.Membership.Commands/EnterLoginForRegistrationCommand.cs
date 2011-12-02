using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class EnterLoginForRegistrationCommand : MessageBase
    {
        public EnterLoginForRegistrationCommand()
        {
        }

        public EnterLoginForRegistrationCommand(Guid registrationId, string userName, string password)
        {
            Id = registrationId;
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
