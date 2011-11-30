using System.ServiceModel.Syndication;
using System.Xml;
using OpenRasta.Codecs;

namespace LifeMap.Common.Infrastructure.OpenRasta
{
    [MediaType("application/rss+xml;q=0.8", "rss")]
    [MediaType("application/xml;q=0.7", "rss")]
    public class RssFeedCodec : SyndicationCodecBase<SyndicationFeed>
    {
        protected override void WriteTo(SyndicationFeed item, XmlWriter writer)
        {
            item.SaveAsRss20(writer);
        }
    }
}