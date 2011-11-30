﻿using System;
using LifeMap.Common.Domain;

namespace LifeMap.Security.Events
{
    [Serializable]
    public class VisitorLoggedInEvent : MessageBase
    {
        public Guid VisitorId { get; set; }
        public Guid LoginId { get; set; }
    }
}