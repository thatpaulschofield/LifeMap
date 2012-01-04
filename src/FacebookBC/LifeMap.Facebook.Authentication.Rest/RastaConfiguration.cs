using LifeMap.Common.Infrastructure.OpenRasta;
using LifeMap.Facebook.Authentication.Rest.Handlers;
using LifeMap.Facebook.Authentication.Rest.Resources;
using OpenRasta.Configuration;
using OpenRasta.DI;
using OpenRasta.Diagnostics;
using log4net;

namespace LifeMap.Facebook.Authentication.Rest
{
    public class RastaConfiguration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.CustomDependency<ILogger,Log4NetLogger>(DependencyLifetime.Singleton);
                ResourceSpace.Uses.Resolver.AddDependencyInstance<ILog>(LogManager.GetLogger("LifeMap"));
                ;

                ResourceSpace.Has.ResourcesOfType<FacebookAuthenticationHeader>()
                    .AtUri("/FacebookAuthenticationHeader/")
                    .HandledBy<FacebookAuthenticationHeaderHandler>()
                    .AsJsonDataContract();

                ResourceSpace.Has.ResourcesOfType<Login>()
                    .AtUri("/Login/")
                    .HandledBy<LoginHandler>()
                    .AsJsonDataContract();

                //ResourceSpace.Has.ResourcesOfType<Offers>()
                //    .AtUri("/registrations/offers/{registrationId}")
                //    .HandledBy<OffersHandler>()
                //    .RenderedByAspx("~/Views/OffersView.aspx");


                //ConfigureFor<OpenRasta.Diagnostics.ILogger>
            }
        }
    }
}
