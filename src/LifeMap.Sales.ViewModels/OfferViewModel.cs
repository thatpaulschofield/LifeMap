using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using LifeMap.Sales.Events;

namespace LifeMap.Sales.ViewModels
{
    public class OfferViewModel
    {
        public Guid Id { get; set; }
        public int DurationInDays { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string TermDescription { get; set; }
        public string BillingDescription { get; set; }
    }
}
