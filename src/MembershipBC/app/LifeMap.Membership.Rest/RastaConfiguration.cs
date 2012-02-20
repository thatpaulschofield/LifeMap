using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Infrastructure.OpenRasta;
using LifeMap.Facebook.Authentication;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Handlers;
using LifeMap.Membership.Rest.Resources;
using OpenRasta.Configuration;
using OpenRasta.DI;
using OpenRasta.Diagnostics;
using log4net;

namespace LifeMap.Membership.Rest
{
    public class RastaConfiguration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.CustomDependency<ILogger,Log4NetLogger>(DependencyLifetime.Singleton);
                ResourceSpace.Uses.Resolver.AddDependencyInstance<ILog>(LogManager.GetLogger("LifeMap"));

                ResourceSpace.Has.ResourcesOfType<Home>()
                    .AtUri("/membership/registrations/home")
                    .HandledBy<HomeHandler>()
                    .AsJsonDataContract();
                
                ResourceSpace.Has.ResourcesOfType<StartRegistration>()
                    .AtUri("/membership/registrations/start")
                    .HandledBy<StartRegistrationHandler>()
                    //.RenderedByAspx("~/Views/StartRegistrationView.aspx")
                    //.And
                    .AsJsonDataContract()
                    //.And.AsXmlDataContract()
                    ;

                ResourceSpace.Has.ResourcesOfType<Registration>()
                    .AtUri("/membership/registrations/{id}")
                    .HandledBy<RegistrationHandler>()
                    .RenderedByAspx("~/Views/RegistrationView.aspx");

                ResourceSpace.Has.ResourcesOfType<RegistrationList>()
                    .AtUri("/membership/registrations")
                    .HandledBy<RegistrationsHandler>()
                    .RenderedByAspx("~/Views/RegistrationsView.aspx");

                ResourceSpace.Has.ResourcesOfType<AddCreditCardInfo>()
                    .AtUri("/membership/registrations/{id}/addCreditCardInfo")
                    .HandledBy<AddCreditCardInfoHandler>()
                    .RenderedByAspx("~/Views/AddCreditCardInfoView.aspx");

                ResourceSpace.Has.ResourcesOfType<Login>()
                    .AtUri("/membership/registrations/{registrationId}/createLogin")
                    .HandledBy<LoginHandler>()
                    .RenderedByAspx("~/Views/LoginView.aspx");

                ResourceSpace.Has.ResourcesOfType<SubmitRegistration>()
                    .AtUri("/membership/registrations/{id}/submit")
                    .HandledBy<SubmitRegistrationHandler>()
                    .RenderedByAspx("~/Views/SubmitRegistrationView");

                ResourceSpace.Has.ResourcesOfType<Offers>()
                    .AtUri("/membership/registrations/offers/{registrationId}")
                    .HandledBy<OffersHandler>()
                    .RenderedByAspx("~/Views/OffersView.aspx");

                ResourceSpace.Has.ResourcesOfType<ConfirmEmailResource>()
                    .AtUri("/membership/registration/confirmEmail")
                    .HandledBy<ConfirmEmailHandler>()
                    .AsJsonDataContract();
                //ConfigureFor<OpenRasta.Diagnostics.ILogger>
            }
        }
    }
}
