using System;

namespace LifeMap.Membership.Rest.Resources
{
    public class StartRegistration
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}