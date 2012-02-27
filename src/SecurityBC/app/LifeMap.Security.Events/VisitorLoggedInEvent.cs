using System;
using System.Runtime.Serialization;
using LifeMap.Common.Domain;


namespace LifeMap.Security.Events
{
    [DataContract, Serializable]
    public class VisitorLoggedInEvent //: MessageBase
    {
        public Guid VisitorId { get; set; }
        public Guid LoginId { get; set; }
    }
}