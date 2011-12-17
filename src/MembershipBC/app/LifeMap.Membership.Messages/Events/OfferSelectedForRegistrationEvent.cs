using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class OfferSelectedForRegistrationEvent : MessageBase, ISpecifyCanSubmitRegistration
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

        public Guid RegistrationId { get; set; }
        public Guid OfferId { get; set; }
        public bool CanSubmitRegistration { get; set; }
    }
}