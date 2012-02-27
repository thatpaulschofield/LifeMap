using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.EmailGateway.Commands
{
    [DataContract, Serializable]
    public class SendEmailCommand : ICommand //: MessageBase
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string To { get; set; }

        [DataMember]
        public string From { get; set; }

        [DataMember]
        public string Body { get; set; }

        public static SendEmailCommand Create(string to, string from, string body)
        {
            return new SendEmailCommand
                       {
                           Id = Guid.NewGuid(),
                           To = to,
                           From = from,
                           Body = body
                       };
        }
    }
}
