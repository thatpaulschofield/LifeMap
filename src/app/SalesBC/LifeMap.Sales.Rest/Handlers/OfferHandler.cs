using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Sales.Commands;
using LifeMap.Sales.ViewModels;
using OpenRasta.Web;

namespace LifeMap.Sales.Rest.Handlers
{
    public class OfferHandler
    {
        public object Get()
        {
            return new OfferViewModel();
        }

        public object Post(Guid productId, int durationInDays, DateTime validFrom, DateTime validTo)
        {
            Guid id = Guid.NewGuid();
            var command = new CreateOfferCommand
                              {
                                  Id = Guid.NewGuid(),
                                  ProductId = productId,
                                  DurationInDays = durationInDays,
                                  ValidFrom = validFrom,
                                  ValidTo = validTo
                              };
            Global.Bus.Publish(command);
            return new OperationResult.SeeOther { RedirectLocation = new OfferViewModel() { Id = id }.CreateUri() };
        }
    }
}
