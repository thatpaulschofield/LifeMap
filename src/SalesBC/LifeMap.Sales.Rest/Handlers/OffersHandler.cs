using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Sales.ViewModels;

namespace LifeMap.Sales.Rest.Handlers
{
    public class OffersHandler
    {
        public object Get()
        {
            return new List<OfferViewModel>
                       {
                           new OfferViewModel
                               {
                                   Id = new Guid("{225F0132-2150-4A7A-A312-E41D8F8A8607}"),
                                   ProductId = new Guid("{2AD12977-B55B-4019-98B2-C2B0FC41AD62}"),
                                   ProductName = "LifeMap",
                                   TermDescription = "12 months",
                                   BillingDescription = "One payment of $39.95"
                               }
                       };
        }
    }
}
