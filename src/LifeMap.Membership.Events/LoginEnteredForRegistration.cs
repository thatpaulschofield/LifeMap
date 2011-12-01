using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class CreditCardInformationEnteredForRegistration : MessageBase
    {
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    [Serializable]
    public class LoginEnteredForRegistration : MessageBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
