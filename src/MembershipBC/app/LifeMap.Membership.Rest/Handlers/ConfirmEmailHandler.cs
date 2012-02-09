using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class ConfirmEmailHandler
    {
        public object Post(ConfirmEmailResource confirmEmail)
        {
            var command = ConfirmEmailAddressCommand.Create(confirmEmail.registrationId, confirmEmail.confirmationId);
            Global.Bus.Send(command);

            return new OperationResult.Created
            {
                ResponseResource = confirmEmail
            }; 
        }
    }
}