using System;
using System.Xml;
using OpenRasta.Codecs;
using OpenRasta.Web;

namespace LifeMap.Common.Infrastructure.OpenRasta
{
    public abstract class SyndicationCodecBase<TEntity> : IMediaTypeWriter where TEntity : class
    {
        public object Configuration
        {
            get { return null; }
            set { }
        }

        public void WriteTo(object entity, IHttpEntity response, string[] codecParameters)
        {
            var item = entity as TEntity;
            if (item == null)
                throw new ArgumentException("Entity was not a " + typeof(TEntity).Name, "entity");

            using (var writer = XmlWriter.Create(response.Stream))
            {
                WriteTo(item, writer);
            }
        }

        protected abstract void WriteTo(TEntity item, XmlWriter writer);
    }
}