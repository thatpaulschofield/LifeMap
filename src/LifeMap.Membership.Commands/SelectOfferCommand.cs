using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Membership.Commands
{
    public class SelectOfferCommand : MessageBase
    {
        public SelectOfferCommand(Guid id, Guid registrationId, Guid offerId)
        {
            base.Id = id;
            RegistrationId = registrationId;
            OfferId = offerId;
        }

        public Guid RegistrationId { get; set; }

        public Guid OfferId { get; set; }
    }
}
