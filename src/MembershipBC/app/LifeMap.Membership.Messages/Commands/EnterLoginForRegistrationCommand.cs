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
            RegistrationId = registrationId;
            UserName = userName;
            Password = password;
        }

        public Guid RegistrationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
