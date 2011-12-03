using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using LifeMap.Membership.Events;

namespace LifeMap.Membership.ViewModels
{
    public class AutomapperConfig
    {
        public void Initialize()
        {
            Mapper.CreateMap<RegistrationStartedEvent, RegistrationViewModel>()
                .ForMember(x => x.OfferId, opts => opts.Ignore())
                .ForMember(x => x.UserName, opts => opts.Ignore())
                .ForMember(x => x.Password, opts => opts.Ignore())
                ;

            Mapper.CreateMap<LoginEnteredForRegistration, RegistrationViewModel>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.FirstName, opts => opts.Ignore())
                .ForMember(x => x.LastName, opts => opts.Ignore())
                .ForMember(x => x.EmailAddress, opts => opts.Ignore())
                .ForMember(x => x.OfferId, opts => opts.Ignore());
        }
    }
}
