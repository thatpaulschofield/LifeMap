using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class StartEmailConfirmationProcessCommand : MessageBase
    {
        public static StartEmailConfirmationProcessCommand Create(string emailAddress)
        {
            return new StartEmailConfirmationProcessCommand
                       {
                           Id = Guid.NewGuid(),
                           EmailAddress = emailAddress
                       };
        }

        public string EmailAddress { get; set; }
    }
}