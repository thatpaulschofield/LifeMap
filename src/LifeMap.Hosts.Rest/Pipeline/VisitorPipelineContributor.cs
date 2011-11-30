using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeMap.Sales.Events;
using OpenRasta.Pipeline;
using OpenRasta.Web;

namespace LifeMap.Hosts.Rest.Pipeline
{
    public class VisitorPipelineContributor : IPipelineContributor
    {
        public void Initialize(IPipeline pipelineRunner)
        {
            pipelineRunner.Notify(NotifyOfVisit).Before<KnownStages.IUriMatching>();
        }

        private static PipelineContinuation NotifyOfVisit(ICommunicationContext context)
        {
            var @event = new VisitorVisitedPageEvent
                             {
                                 Id = HttpContext.Current.GetVisitorId(),
                                 PageUrl = context.Request.Uri.ToString()
                             };
            Global.Bus.Publish(@event);
            return PipelineContinuation.Continue;
        }
    }

    public static class HttpSessionExtensions
    {
        public static Guid GetVisitorId(this HttpContext context)
        {
            if (context.Session[SessionNames.VisitorId] is Guid)
            {
                return (Guid) context.Session[SessionNames.VisitorId];
            }
            else
            {
                Guid visitorId = Guid.NewGuid();
                context.Session[SessionNames.VisitorId] = visitorId;
                return visitorId;
            }
        }
    }

    public static class SessionNames
    {
        public const string VisitorId = "VisitorId";
    }
}