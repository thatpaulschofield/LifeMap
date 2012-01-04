using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Facebook.Authentication.Rest.Resources;

namespace LifeMap.Facebook.Authentication.Rest.Handlers
{
    public class LoginHandler
    {
        public object Get()
        {
            return new Login();
        }
    }
}