using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LifeMap.Facebook
{
    public class AccessToken
    {
        private string _value;

        public AccessToken(string value)
        {
            _value = value;
        }

        public static implicit operator string(AccessToken t)
        {
            return t._value;
        }

        public static implicit operator AccessToken(string s)
        {
            return new AccessToken(s);
        }
    }
}
