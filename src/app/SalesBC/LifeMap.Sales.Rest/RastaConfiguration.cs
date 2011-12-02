using System.Collections.Generic;
using LifeMap.Common.Infrastructure.OpenRasta;
using LifeMap.Sales.Rest.Handlers;
using LifeMap.Sales.ViewModels;
using OpenRasta.Configuration;

namespace LifeMap.Sales.Rest
{
    public class RastaConfiguration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<IList<OfferViewModel>>()
                    .AtUri("/offers")
                    .HandledBy<OffersHandler>()
                    .TranscodedBy<JsonpDataContractCodec>();

                ResourceSpace.Has.ResourcesOfType<OfferViewModel>()
                    .AtUri("/offers/create")
                    .HandledBy<OfferHandler>()
                    .RenderedByAspx("~/Views/OfferView.aspx");
            }
        }
    }
}
