using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using OpenRasta.Codecs;

namespace LifeMap.Common.Infrastructure.OpenRasta
{
    [MediaType("application/atom+xml;q=0.9", "atom")]
    [MediaType("application/atom;q=0.9", "atom")]
    public class AtomFeedCodec : SyndicationCodecBase<SyndicationFeed>
    {
        protected override void WriteTo(SyndicationFeed item, XmlWriter writer)
        {
            item.SaveAsAtom10(writer);
        }
    }
}
