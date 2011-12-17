using System;

namespace LifeMap.Membership.RegistrationProcess
{
    public class RegistrationLogin
    {

        public RegistrationLogin(Guid loginId)
        {
            LoginId = loginId;
        }

        public Guid LoginId { get; private set; }
    }
}