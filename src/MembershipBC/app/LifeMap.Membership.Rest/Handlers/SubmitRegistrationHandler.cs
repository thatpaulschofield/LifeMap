using System;
using AutoMapper;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;

namespace LifeMap.Membership.Rest.Handlers
{
    public class SubmitRegistrationHandler
    {
        public object Get(Guid id)
        {
            return new SubmitRegistration();
        }

        public void Post(SubmitRegistration resource)
        {
            var command = Mapper.Map<SubmitRegistration, SubmitRegistrationCommand>(resource);
            Global.Bus.Send(command);
        }
    }
}