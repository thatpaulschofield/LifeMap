using Autofac;
using LifeMap.Common.Infrastructure;
using NServiceBus;

namespace LifeMap.Sales.ViewModels
{
    public class EndpointConfig : ViewModelEndpointConfig, IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public EndpointConfig()
        {
            this.RavenUrl = "http://localhost:8080/databases/Sales/";

            new AutomapperConfig().Initialize();
        }
    }
}
