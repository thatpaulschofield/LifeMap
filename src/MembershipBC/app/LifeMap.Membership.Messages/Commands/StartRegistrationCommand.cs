using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class StartRegistrationCommand : MessageBase
    {
        public StartRegistrationCommand()
        {
        }

        public StartRegistrationCommand(Guid id, string firstName, string lastName, string emailAddress)
        {
            base.Id = id;
            RegistrationId = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public Guid RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

    }
}
