using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Handlers;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;
using OpenRasta.Configuration;

namespace LifeMap.Membership.Rest
{
    public class RastaConfiguration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<StartRegistrationCommand>()
                    .AtUri("/registration/start")
                    .HandledBy<StartRegistrationHandler>()
                    .RenderedByAspx("~/Views/StartRegistrationView.aspx")
                    .And.AsJsonDataContract()
                    //.And.AsXmlDataContract()
                    ;

                ResourceSpace.Has.ResourcesOfType<RegistrationViewModel>()
                    .AtUri("/registration/{id}")
                    .HandledBy<RegistrationHandler>()
                    .RenderedByAspx("~/Views/RegistrationView.aspx");

                ResourceSpace.Has.ResourcesOfType<Offers>()
                    .AtUri("/registration/offers/{registrationId}")
                    .HandledBy<OffersHandler>()
                    .RenderedByAspx("~/Views/OffersView.aspx");

                ResourceSpace.Has.ResourcesOfType<Login>()
                    .AtUri("/registration/{registrationId}/createLogin")
                    .HandledBy<LoginHandler>()
                    .RenderedByAspx("~/Views/LoginView.aspx");
            }
        }
    }
}
