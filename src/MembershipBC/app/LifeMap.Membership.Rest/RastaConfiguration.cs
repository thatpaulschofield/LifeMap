using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Handlers;
using LifeMap.Membership.Rest.Resources;
using OpenRasta.Configuration;

namespace LifeMap.Membership.Rest
{
    public class RastaConfiguration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<StartRegistration>()
                    .AtUri("/registrations/start")
                    .HandledBy<StartRegistrationHandler>()
                    .RenderedByAspx("~/Views/StartRegistrationView.aspx")
                    .And.AsJsonDataContract()
                    //.And.AsXmlDataContract()
                    ;

                ResourceSpace.Has.ResourcesOfType<Registration>()
                    .AtUri("/registrations/{id}")
                    .HandledBy<RegistrationHandler>()
                    .RenderedByAspx("~/Views/RegistrationView.aspx");

                ResourceSpace.Has.ResourcesOfType<IList<Registration>>()
                    .AtUri("/registrations")
                    .HandledBy<RegistrationsHandler>()
                    .RenderedByAspx("~/Views/RegistrationsView.aspx");

                ResourceSpace.Has.ResourcesOfType<AddCreditCardInfo>()
                    .AtUri("/registrations/{id}/addCreditCardInfo")
                    .HandledBy<AddCreditCardInfoHandler>()
                    .RenderedByAspx("~/Views/AddCreditCardInfoView.aspx");

                ResourceSpace.Has.ResourcesOfType<SubmitRegistration>()
                    .AtUri("/registrations/{id}/submit")
                    .HandledBy<SubmitRegistrationHandler>()
                    .RenderedByAspx("~/Views/SubmitRegistrationView");

                ResourceSpace.Has.ResourcesOfType<Offers>()
                    .AtUri("/registrations/offers/{registrationId}")
                    .HandledBy<OffersHandler>()
                    .RenderedByAspx("~/Views/OffersView.aspx");

                ResourceSpace.Has.ResourcesOfType<Login>()
                    .AtUri("/registrations/{registrationId}/createLogin")
                    .HandledBy<LoginHandler>()
                    .RenderedByAspx("~/Views/LoginView.aspx");

                //ConfigureFor<OpenRasta.Diagnostics.ILogger>
            }
        }
    }
}
