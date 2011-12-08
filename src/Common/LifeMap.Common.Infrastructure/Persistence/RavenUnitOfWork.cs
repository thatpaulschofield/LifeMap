using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.UnitOfWork;
using Raven.Client;

namespace LifeMap.Common.Infrastructure.Persistence
{
    public class RavenUnitOfWork : IManageUnitsOfWork
    {
        readonly IDocumentSession session;

        public RavenUnitOfWork(IDocumentSession session)
        {
            this.session = session;
        }

        public void Begin()
        {
        }

        public void End()
        {
            session.SaveChanges();
        }

        public void Error()
        {
        }

    }
}
