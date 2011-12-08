using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class OfferSelectedForRegistrationEvent : MessageBase
    {
        public OfferSelectedForRegistrationEvent()
        {
            Id = Guid.NewGuid();
        }

        public OfferSelectedForRegistrationEvent(Guid registrationId, Guid offerId) : this()
        {
            RegistrationId = registrationId;
            OfferId = offerId;
        }

        public Guid RegistrationId { get; set; }

        public Guid OfferId { get; set; }
    }
}