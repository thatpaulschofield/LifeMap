using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Hosts.Rest.Resources;

namespace LifeMap.Hosts.Rest.Handlers
{
    public class HomeHandler
    {
        public object Get()
        {
            return new Home();
        }
    }
}