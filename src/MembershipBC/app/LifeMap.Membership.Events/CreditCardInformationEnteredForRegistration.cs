using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class CreditCardInformationEnteredForRegistration : MessageBase
    {
        public Guid RegistrationId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}