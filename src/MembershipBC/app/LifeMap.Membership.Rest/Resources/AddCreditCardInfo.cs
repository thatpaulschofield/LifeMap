using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeMap.Membership.Rest.Resources
{
    public class AddCreditCardInfo
    {
        public AddCreditCardInfo()
        {
        }

        public AddCreditCardInfo(Guid registrationId)
        {
            Id = registrationId;
        }

        public Guid Id { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}