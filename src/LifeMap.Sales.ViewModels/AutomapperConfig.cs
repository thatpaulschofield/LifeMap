using AutoMapper;
using LifeMap.Sales.Events;

namespace LifeMap.Sales.ViewModels
{
    public class AutomapperConfig
    {
        public void Initialize()
        {
            Mapper.CreateMap<OfferCreatedEvent, OfferViewModel>()
                .ForMember(x => x.BillingDescription, opts => opts.Ignore())
                .ForMember(x => x.TermDescription, opts => opts.Ignore())
                .ForMember(x => x.ProductName, opts => opts.Ignore());
        }
    }
}
