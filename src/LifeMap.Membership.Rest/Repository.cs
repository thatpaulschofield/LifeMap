using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Document;

namespace LifeMap.Membership.Rest
{
    public static class Repository
    {
        static Repository()
        {
            Instance = BuildRavenClient();
        }

        private static IDocumentStore BuildRavenClient()
        {
            var documentStore = new DocumentStore { Url = "http://localhost:8080/databases/MembershipViewModels" };
            documentStore.Initialize();
            return documentStore;
        }
        public static IDocumentStore Instance { get; private set; }
    }
}
