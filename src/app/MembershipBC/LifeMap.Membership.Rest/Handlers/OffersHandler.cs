using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class OffersHandler
    {
        public object Get(Guid registrationId)
        {
            return new Offers(registrationId);
        }

        public object Post(Guid offerId, Guid registrationId)
        {
            var command = new SelectOfferCommand(Guid.NewGuid(), registrationId, offerId);
            Global.Bus.Publish(command);
            return new OperationResult.SeeOther { RedirectLocation = new RegistrationViewModel { Id = registrationId }.CreateUri() };

        }
    }
}