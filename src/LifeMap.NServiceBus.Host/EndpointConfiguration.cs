using NServiceBus;

namespace LifeMap.NServiceBus.Host
{
    public class EndpointConfiguration : IConfigureThisEndpoint, AsA_Host, IWantCustomInitialization
    {

        public void Init()
        {
            Configure
                .With(AllAssemblies.Except("NServiceBus.Hosting.Azure.HostProcess.exe"))
                .DefaultBuilder();
        }
    }
}