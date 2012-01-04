using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Messages.Events
{
    [Serializable]
    public class RegistrationSubmittedEvent : MessageBase
    {
        public Guid RegistrationId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}