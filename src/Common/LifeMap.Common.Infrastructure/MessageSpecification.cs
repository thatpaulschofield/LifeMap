using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeMap.Common.Infrastructure
{
    public class MessageSpecification
    {
        public static bool IsCommand(Type x)
        {
            try
            {
                bool isCommand = x.Namespace != null && x.Namespace.StartsWith("LifeMap") &&
                       (x.Namespace.EndsWith("Commands") || x.Name.EndsWith("Command"));
                return isCommand;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsEvent(Type x)
        {
            try
            {
                return x.Namespace != null && x.Namespace.StartsWith("LifeMap") &&
       (x.Namespace.EndsWith("Events") || x.Name.EndsWith("Event"));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsMessage(Type x)
        {
            return false;
            //x.Namespace != null && x.Namespace.StartsWith("LifeMap") &&
            //   (x.Namespace.EndsWith("Messages") || x.Name.EndsWith("Message"));
        }
    }
}
