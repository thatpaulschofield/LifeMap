using System;

namespace LifeMap.Membership.Rest.Resources
{
    public class SubmitRegistration
    {
        public SubmitRegistration()
        {
        }

        public SubmitRegistration(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}