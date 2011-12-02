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
    public class LoginHandler
    {
        public object Get(Guid registrationId)
        {
            return new Login(registrationId);
        }
        public object Post(Guid registrationId, string userName, string password)
        {
            var command = new EnterLoginForRegistrationCommand(registrationId, userName, password);
            Global.Bus.Publish(command);
            return new OperationResult.SeeOther { RedirectLocation = new RegistrationViewModel { Id = registrationId }.CreateUri() };
        }
        public object Post(Login login)
        {
            var command = new EnterLoginForRegistrationCommand(login.RegistrationId, login.UserName, login.Password);
            Global.Bus.Publish(command);
            return new OperationResult.SeeOther { RedirectLocation = new RegistrationViewModel { Id = login.RegistrationId }.CreateUri() };
        }
    }
}