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
            return new StartRegistration
                       {
                           Id = Guid.NewGuid().ToString()
                       };
        }

        public object Post(StartRegistration post)
        {
            if (String.IsNullOrEmpty(post.Id))
                post.Id = Guid.NewGuid().ToString();
            try
            {
                var resource = new StartRegistrationCommand(Guid.Parse(post.Id), post.FirstName, post.LastName, post.EmailAddress);
                Global.Bus.Send(resource);
                return new OperationResult.Created
                {
                    ResponseResource = post
                }; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}