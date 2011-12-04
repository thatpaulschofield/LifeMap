using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;

namespace LifeMap.Membership.Rest
{
    public class AutomapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.CreateMap<RegistrationViewModel, Registration>().ConstructUsing(x => Registration.Create())
                ;

            Mapper.CreateMap<SubmitRegistration, SubmitRegistrationCommand>();

            Mapper.CreateMap<StartRegistration, StartRegistrationCommand>();

            Mapper.CreateMap<RegistrationViewModel, AddCreditCardInfo>();
        }
    }
}