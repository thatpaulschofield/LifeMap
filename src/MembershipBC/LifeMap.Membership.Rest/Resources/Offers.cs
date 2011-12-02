using System;

namespace LifeMap.Membership.Rest.Resources
{
    public class Offers
    {
        public Offers(Guid registrationId)
        {
            RegistrationId = registrationId;
        }

        public Guid RegistrationId { get; set; }
    }
}