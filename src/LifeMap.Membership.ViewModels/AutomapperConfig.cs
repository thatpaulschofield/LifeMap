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
                .ForMember(x => x.OfferId, opts => opts.Ignore());
        }
    }
}
