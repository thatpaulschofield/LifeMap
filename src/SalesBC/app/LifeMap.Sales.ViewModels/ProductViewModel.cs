using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Sales.Events;

namespace LifeMap.Sales.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Handle(ProductCreatedEvent @event)
        {
            if (@event == null) throw new ArgumentNullException("event");
            this.Id = @event.ProductId;
            this.Name = @event.Name;
        }
    }
}
