﻿using System;

namespace LifeMap.Membership.Rest.Resources
{
    public class StartRegistration
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}