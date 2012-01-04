using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.EmailGateway.Commands
{
    [Serializable]
    public class SendEmailCommand : MessageBase
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }

        public static SendEmailCommand Create(string to, string from, string body)
        {
            return new SendEmailCommand
                       {
                           To = to,
                           From = from,
                           Body = body
                       };
        }
    }
}
