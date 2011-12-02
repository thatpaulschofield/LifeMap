using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeMap.Membership.RegistrationProcess
{
    public class RegistrationCreditCard
    {
        public RegistrationCreditCard(string nameOnCard, string cardNumber, string cvvNumber, DateTime expirationDate)
        {
            NameOnCard = nameOnCard;
            CardNumber = cardNumber;
            CvvNumber = cvvNumber;
            ExpirationDate = expirationDate;
        }

        public string NameOnCard { get; private set; }
        public string CardNumber { get; private set; }
        public string CvvNumber { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}
