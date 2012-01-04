using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Resources
{
    public class Home
    {
        public Home()
        {
            Links = new List<Link> { new Link { Description="Register", Uri = new StartRegistration().CreateUri() } };
        }

        public List<Link> Links { get; set; }
    }
   
}