using System;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class OfferSelectedForRegistration : MessageBase
    {
        private OfferSelectedForRegistration()
        {
        }

        public OfferSelectedForRegistration(Guid registrationId, Guid offerId)
        {
            base.Id = registrationId;
            OfferId = offerId;
        }

        public Guid OfferId { get; set; }
    }
}