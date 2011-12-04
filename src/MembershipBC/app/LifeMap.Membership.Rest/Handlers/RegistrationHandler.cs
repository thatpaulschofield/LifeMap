using System;
using AutoMapper;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;
using System.Linq;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class RegistrationHandler
    {
        public object Get(string id)
        {
            var vm =
                Repository.Instance.OpenSession().Query<RegistrationViewModel>().Where(x => x.Id == new Guid(id)).
                    SingleOrDefault();
            if (vm == null)
                return new OperationResult.NotFound();
            Registration registration;
            try
            {
                registration = Mapper.Map<RegistrationViewModel, Registration>(vm);
            }
            catch (Exception)
            {
                throw;
            }
            return registration;
        }
    }
}