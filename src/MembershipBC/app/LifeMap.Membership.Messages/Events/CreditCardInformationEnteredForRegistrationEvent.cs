﻿using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class CreditCardInformationEnteredForRegistrationEvent : MessageBase
    {
        public Guid RegistrationId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}