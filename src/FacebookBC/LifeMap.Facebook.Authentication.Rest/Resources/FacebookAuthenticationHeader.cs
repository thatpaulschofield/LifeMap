using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeMap.Facebook.Authentication.Rest.Resources
{
    public class FacebookAuthenticationHeader
    {
        public object[] Links
        {
            get
            {
                return new[]
                           {
                               new
                                   {
                                       Uri = "/test",
                                       Description = "Login with Facebook"
                                   }
                           };
            }
        }
    }
}