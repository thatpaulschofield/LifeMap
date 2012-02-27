using System;
using System.Runtime.Serialization;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class CreditCardInformationEnteredForRegistrationEvent //: MessageBase, ISpecifyCanSubmitRegistration
    {
        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public string NameOnCard { get; set; }

        [DataMember]
        public string CardNumber { get; set; }

        [DataMember]
        public string CvvNumber { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }

        [DataMember]
        public bool CanSubmitRegistration { get; set; }

        [DataMember]
        public Guid Id { get; set; }
    }
}