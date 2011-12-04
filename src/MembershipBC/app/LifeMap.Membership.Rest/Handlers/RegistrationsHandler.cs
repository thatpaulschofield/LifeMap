using System;
using System.Collections.Generic;
using AutoMapper;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;

namespace LifeMap.Membership.Rest.Handlers
{
    public class RegistrationsHandler
    {
        public object Get()
        {
            var vms = Repository.Instance.OpenSession().Query<RegistrationViewModel>();
            List<Registration> registrations = new List<Registration>();
            foreach (var vm in vms)
            {
                Registration registration;
                try
                {
                    registration = Mapper.Map<RegistrationViewModel, Registration>(vm);
                }
                catch (Exception)
                {
                    throw;
                }    
                registrations.Add(registration);
            }
            
            return registrations;
        }
    }
}