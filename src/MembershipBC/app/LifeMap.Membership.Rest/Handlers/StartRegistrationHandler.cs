using System;
using LifeMap.Common.Infrastructure;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.RestHost;
using LifeMap.Membership.ViewModels;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class StartRegistrationHandler
    {
        public object Get()
        {
            return new StartRegistration();
        }

        public object Post(string firstName, string lastName, string emailAddress)
        {
            Guid id = Guid.NewGuid();
            try
            {
                var resource = new StartRegistrationCommand(id, firstName, lastName, emailAddress);
                Global.Bus.Send(resource);
                return new OperationResult.SeeOther{ RedirectLocation = Registration.Create(id).CreateUri() };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}