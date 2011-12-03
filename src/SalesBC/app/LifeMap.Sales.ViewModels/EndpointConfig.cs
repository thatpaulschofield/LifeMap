using Autofac;
using LifeMap.Common.Infrastructure;
using NServiceBus;

namespace LifeMap.Sales.ViewModels
{
    public class EndpointConfig : ViewModelEndpointConfig, IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public EndpointConfig()
        {
            this.ConnectionStringName = "SalesViewModels";

            new AutomapperConfig().Initialize();
        }
    }
}
