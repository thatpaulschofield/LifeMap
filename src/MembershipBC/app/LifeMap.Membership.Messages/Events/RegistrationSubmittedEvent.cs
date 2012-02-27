using System;
using System.Runtime.Serialization;


namespace LifeMap.Membership.Messages.Events
{
    [DataContract, Serializable]
    public class RegistrationSubmittedEvent //: MessageBase
    {

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RegistrationId { get; set; }


        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }


        [DataMember]
        public string NameOnCard { get; set; }

        [DataMember]
        public string CardNumber { get; set; }

        [DataMember]
        public string CvvNumber { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }


        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}