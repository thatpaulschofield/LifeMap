using System;
using LifeMap.Membership.ViewModels;
using System.Linq;

namespace LifeMap.Membership.Rest.Handlers
{
    public class RegistrationHandler
    {
        public object Get(string id)
        {
            var vm =
                Repository.Instance.OpenSession().Query<RegistrationViewModel>().Where(x => x.Id == new Guid(id)).
                    SingleOrDefault();
                //.Load<RegistrationViewModel>(id);
            return vm;
        }
    }
}