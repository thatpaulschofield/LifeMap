using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class StartRegistration : MessageBase, ICommand
    {
        public StartRegistration()
        {
        }

        public StartRegistration(Guid id, string firstName, string lastName, string emailAddress)
        {
            base.Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
