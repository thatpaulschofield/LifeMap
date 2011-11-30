using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using LifeMap.Common.Infrastructure.OpenRasta;
using LifeMap.Hosts.Rest.Handlers;
using LifeMap.Hosts.Rest.Pipeline;
using LifeMap.Hosts.Rest.Resources;
using LifeMap.Hosts.Rest.Views.Security;
using LifeMap.Security.Rest.Handlers;
using LifeMap.Security.Rest.Resources;
using OpenRasta.Configuration;
using OpenRasta.Configuration.Fluent;
using OpenRasta.DI;
using Raven.Client;
using Raven.Client.Document;

namespace LifeMap.Hosts.Rest.Configuration
{
    public class RastaConfiguration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<Home>()
                    .AtUri("/home")
                    .HandledBy<HomeHandler>()
                    .RenderedByAspx("~/Views/Home.aspx");

                ResourceSpace.Has.ResourcesOfType<LogIn>()
                    .AtUri("/security/logIn")
                    .HandledBy<LoginHandler>()
                    .RenderedByAspx("~/Views/Security/LoginView.aspx");

                ResourceSpace.Uses.PipelineContributor<VisitorPipelineContributor>();
            }
        }

    }
}