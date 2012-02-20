using LifeMap.Common.Infrastructure;
using NServiceBus;
using NServiceBus.Hosting.Azure;

namespace LifeMap.Analysis.ViewModels
{
    public class Host : RoleEntryPoint { }

    public class EndpointConfig : ViewModelEndpointConfig, IConfigureThisEndpoint, AsA_Worker, IWantCustomInitialization
    {
        public EndpointConfig()
        {
            this.RavenUrl = "http://localhost:8080/databases/AnalysisViewModels";

            new AutomapperConfig().Initialize();
        }
    }
}
