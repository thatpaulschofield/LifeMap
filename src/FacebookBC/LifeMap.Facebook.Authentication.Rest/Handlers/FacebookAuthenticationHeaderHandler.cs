using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Facebook;
using LifeMap.Facebook.Authentication.Events;
using LifeMap.Facebook.Authentication.Rest.Resources;
using OpenRasta.Web;

namespace LifeMap.Facebook.Authentication.Rest.Handlers
{
    public class FacebookAuthenticationHeaderHandler
    {
        static string loginUri = "http://localhost/FacebookAuthentication/login";

        public object Get()
        {
            return new OperationResult.SeeOther
                       {
                           RedirectLocation =
                               new Uri(
                               "http://www.facebook.com/dialog/oauth?client_id=149734561800297&redirect_uri=" + loginUri + "&scope=read_stream,user_interests,user_education_history,user_birthday,user_about_me,user_activities,offline_access")
                       };
            
        }

        public object Get(Guid registrationId, string afterLogin)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("registrationId", registrationId.ToString()));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("afterLogin", afterLogin));
            return new OperationResult.SeeOther
            {
                RedirectLocation =
                    new Uri(
                    "http://www.facebook.com/dialog/oauth?client_id=149734561800297&scope=read_stream,user_interests,user_education_history,user_birthday,user_about_me,user_activities,offline_access&redirect_uri=http://localhost:62571/login")
            };

           
        }

        public object Get(string code)
        {
            string registrationId = HttpContext.Current.Request.Cookies["registrationId"].Value;
            LogIn(code, registrationId);
            string redirectUrl = HttpContext.Current.Request.Cookies["afterLogin"].Value;
            
            return new OperationResult.SeeOther
            {
                RedirectLocation = new Uri(redirectUrl)
            };
        }

        private static void LogIn(string code, string registrationId)
        {
            var settings = ConfigurationManager.GetSection("facebookSettings");
            IFacebookApplication fbApp = null;

            if (settings != null)
            {
                fbApp = settings as IFacebookApplication;
            }
            FacebookOAuthClient cl = new FacebookOAuthClient(fbApp);
            FacebookOAuthResult result = null;
            string url = HttpContext.Current.Request.Url.OriginalString;

            // verify that there is a code in the url
            if (FacebookOAuthResult.TryParse(url, out result))
            {
                if (result.IsSuccess)
                {
                    cl.RedirectUri = new Uri(loginUri);

                    var parameters = new Dictionary<string, object>();

                    parameters.Add("permissions", "offline_access");

                    dynamic accessTokenResponse =
                        cl.ExchangeCodeForAccessToken(code,
                                                      new Dictionary<string, object>
                                                          {
                                                              {"redirect_uri", loginUri}
                                                          });

                    string token = accessTokenResponse.access_token as string;

                    dynamic me = new FacebookClient(token).Get("me");
                    int facebookId = Int32.Parse(me.id);

                    Global.Bus.Publish(new FacebookUserAuthenticatedForRegistrationEvent(registrationId, facebookId, code, token));
                }
            }
        }
    }
}