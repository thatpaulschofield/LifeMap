using System;
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

            return vm;
        }
    }
}