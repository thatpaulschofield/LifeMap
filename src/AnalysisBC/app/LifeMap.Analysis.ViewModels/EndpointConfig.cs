using LifeMap.Common.Infrastructure;
using NServiceBus;

namespace LifeMap.Analysis.ViewModels
{
    public class EndpointConfig : ViewModelEndpointConfig, IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public EndpointConfig()
        {
            this.RavenUrl = "http://localhost:8080/databases/AnalysisViewModels";

            new AutomapperConfig().Initialize();
        }
    }
}
