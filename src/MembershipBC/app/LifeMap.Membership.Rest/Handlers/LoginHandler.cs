using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Messages.Commands;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class LoginHandler
    {
        public object Get(Guid registrationId)
        {
            return new Login(registrationId);
        }

        public object Post(Guid registrationId, Guid loginId)
        {
            var command = new SelectLoginForRegistrationCommand(registrationId, loginId);
            Global.Bus.Publish(command);
            return new OperationResult.SeeOther { RedirectLocation = new Registration { Id = registrationId }.CreateUri() };
        }
    }
}