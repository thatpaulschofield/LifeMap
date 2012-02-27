using System;
using System.Runtime.Serialization;
using NServiceBus;

namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class EnterCreditCardInformationForRegistrationCommand : ICommand //: MessageBase
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
        public Guid Id { get; set; }
    }
}