using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Membership.Events;

namespace LifeMap.Membership.ViewModels
{
    public class RegistrationViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid OfferId { get; set; }

        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        public bool CanAddCreditCardInfo { get; set; }
        public bool CanAddLogin { get; set; }
        public bool CanSubmit { get; set; }
    }
}
