using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using Raven.Database.Indexing;
public class Index_Raven_2fDocumentsByExpirationDate : AbstractViewGenerator
{
	public Index_Raven_2fDocumentsByExpirationDate()
	{
		this.ViewText = @"
	from doc in docs
	let expiry = doc[""@metadata""][""Raven-Expiration-Date""]
	where expiry != null
	select new { Expiry = expiry }

";
		this.AddMapDefinition(docs => from doc in docs
			let expiry = doc["@metadata"]["Raven-Expiration-Date"]
			where expiry != null
			select new { Expiry = expiry, __document_id = doc.__document_id });
		this.AddField("Expiry");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("__document_id");
	}
}
