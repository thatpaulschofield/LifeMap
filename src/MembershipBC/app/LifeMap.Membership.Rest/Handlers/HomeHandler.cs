using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Membership.Rest.Resources;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class HomeHandler
    {
        public object Get()
        {
            return new Home();
        }
    }
}