using System;
using System.Runtime.Serialization;


namespace LifeMap.Membership.Events
{
    [DataContract, Serializable]
    public class OfferSelectedForRegistrationEvent //: MessageBase, ISpecifyCanSubmitRegistration
    {
        public OfferSelectedForRegistrationEvent()
        {
            Id = Guid.NewGuid();
        }

        public OfferSelectedForRegistrationEvent(Guid registrationId, Guid offerId, bool canSubmit) : this()
        {
            RegistrationId = registrationId;
            OfferId = offerId;
            CanSubmitRegistration = canSubmit;
        }

        [DataMember]
        public Guid Id { get; set; }


        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid OfferId { get; set; }

        [DataMember]
        public bool CanSubmitRegistration { get; set; }
    }
}