﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Sales.Events
{
    public class ProductCreatedEvent : MessageBase
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
