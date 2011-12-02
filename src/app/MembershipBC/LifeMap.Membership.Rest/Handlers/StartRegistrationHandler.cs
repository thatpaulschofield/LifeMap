using System;
using LifeMap.Common.Infrastructure;
using LifeMap.Membership.Commands;
using LifeMap.Membership.RestHost;
using LifeMap.Membership.ViewModels;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class StartRegistrationHandler
    {
        public object Get()
        {
            return new StartRegistrationCommand();
        }

        public object Post(string firstName, string lastName, string emailAddress)
        {
            Guid id = Guid.NewGuid();
            try
            {
                var resource = new StartRegistrationCommand(id, firstName, lastName, emailAddress);
                Global.Bus.Publish(resource);
                return new OperationResult.SeeOther{ RedirectLocation = new RegistrationViewModel{Id = id}.CreateUri() };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}