using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Events
{
    public class ProductCreatedEvent : MessageBase
    {
        public string Name { get; set; }
    }
}
