using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using NServiceBus;


namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class StartRegistrationCommand : ICommand
    {
        public StartRegistrationCommand()
        {
        }

        public StartRegistrationCommand(Guid id, string firstName, string lastName, string emailAddress)
        {
            Id = id;
            RegistrationId = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }
        
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
        
        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
