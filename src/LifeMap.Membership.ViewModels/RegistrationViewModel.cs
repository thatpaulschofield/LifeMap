using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Membership.Events;

namespace LifeMap.Membership.ViewModels
{
    public class RegistrationViewModel
    {
        public void Handle(RegistrationStartedEvent message)
        {
            Id = message.Id;
            FirstName = message.FirstName;
            LastName = message.LastName;
            EmailAddress = message.EmailAddress;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid OfferId { get; set; }
    }
}
