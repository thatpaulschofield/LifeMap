using Microsoft.WindowsAzure.ServiceRuntime;
using NServiceBus;

namespace LifeMap.Worker
{
    public class Host : RoleEntryPoint { }

    public class EndpointConfiguration : IConfigureThisEndpoint, AsA_Host { }

}
