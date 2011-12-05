﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Membership.Commands
{
    [Serializable]
    public class SelectOfferCommand : MessageBase
    {
        public SelectOfferCommand(Guid registrationId, Guid offerId)
        {
            RegistrationId = registrationId;
            OfferId = offerId;
        }

        public Guid RegistrationId { get; set; }

        public Guid OfferId { get; set; }
    }
}
