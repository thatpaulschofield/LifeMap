using System;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Events
{
    [Serializable]
    public class OfferSelectedForRegistration : MessageBase
    {
        public OfferSelectedForRegistration()
        {
        }

        public OfferSelectedForRegistration(Guid registrationId, Guid offerId)
        {
            RegistrationId = registrationId;
            OfferId = offerId;
        }

        public Guid RegistrationId { get; set; }

        public Guid OfferId { get; set; }
    }
}