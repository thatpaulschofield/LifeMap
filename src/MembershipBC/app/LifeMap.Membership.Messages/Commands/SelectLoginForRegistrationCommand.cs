using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Messages.Commands
{
    [Serializable]
    public class SelectLoginForRegistrationCommand : MessageBase
    {
        public SelectLoginForRegistrationCommand()
        {
            Id = Guid.NewGuid();
        }

        public SelectLoginForRegistrationCommand(Guid registrationId, Guid loginId) : this()
        {
            RegistrationId = registrationId;
            LoginId = loginId;
        }

        public Guid RegistrationId { get; set; }
        public Guid LoginId { get; set; }
    }
}
