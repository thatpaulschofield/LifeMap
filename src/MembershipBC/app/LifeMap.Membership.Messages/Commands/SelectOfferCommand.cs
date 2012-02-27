using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using NServiceBus;


namespace LifeMap.Membership.Commands
{
    [DataContract, Serializable]
    public class SelectOfferCommand : ICommand //: MessageBase
    {
        public SelectOfferCommand()
        {
        }

        public SelectOfferCommand(Guid registrationId, Guid offerId)
        {
            RegistrationId = registrationId;
            OfferId = offerId;
        }


        [DataMember]
        public Guid RegistrationId { get; set; }

        [DataMember]
        public Guid OfferId { get; set; }
    }
}
