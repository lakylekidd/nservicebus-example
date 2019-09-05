using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;

public class Index_EndpointsIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_EndpointsIndex()
	{
		this.ViewText = @"from message in docs.ProcessedMessages
select new {
	message = message,
	sending = (message.MessageMetadata[""SendingEndpoint""])
} into this0
select new {
	this0 = this0,
	receiving = (this0.message.MessageMetadata[""ReceivingEndpoint""])
} into this1
from endpoint in new[] {
	this1.this0.sending,
	this1.receiving
}
select new {
	this1 = this1,
	endpoint = endpoint
} into this2
where this2.endpoint != null
select new {
	Host = this2.endpoint.Host,
	HostId = this2.endpoint.HostId,
	Name = this2.endpoint.Name
}
from result in results
group result by new {
	Name = result.Name,
	HostId = result.HostId
} into grouped
select new {
	grouped = grouped,
	first = DynamicEnumerable.FirstOrDefault(grouped)
} into this0
select new {
	Host = this0.first.Host,
	HostId = this0.first.HostId,
	Name = this0.first.Name
}";
		this.ForEntityNames.Add("ProcessedMessages");
		this.AddMapDefinition(docs => 
			from message in ((IEnumerable<dynamic>)docs)
			where string.Equals(message["@metadata"]["Raven-Entity-Name"], "ProcessedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				message = message,
				sending = (message.MessageMetadata["SendingEndpoint"]),
				__document_id = message.__document_id
			} into this0
			select new {
				this0 = this0,
				receiving = (this0.message.MessageMetadata["ReceivingEndpoint"]),
				__document_id = this0.__document_id
			} into this1
			from endpoint in ((IEnumerable<dynamic>)new[] {
				this1.this0.sending,
				this1.receiving
			})
			select new {
				this1 = this1,
				endpoint = endpoint,
				__document_id = this1.__document_id
			} into this2
			where this2.endpoint != null
			select new {
				Host = this2.endpoint.Host,
				HostId = this2.endpoint.HostId,
				Name = this2.endpoint.Name,
				__document_id = this2.__document_id
			});
		this.ReduceDefinition = results => 
			from result in results
			group result by new {
				Name = result.Name,
				HostId = result.HostId
			} into grouped
			select new {
				grouped = grouped,
				first = DynamicEnumerable.FirstOrDefault(grouped)
			} into this0
			select new {
				Host = this0.first.Host,
				HostId = this0.first.HostId,
				Name = this0.first.Name
			};
		this.GroupByExtraction = result => new {
			Name = result.Name,
			HostId = result.HostId
		};
		this.AddField("Host");
		this.AddField("HostId");
		this.AddField("Name");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("endpoint.Host");
		this.AddQueryParameterForMap("endpoint.HostId");
		this.AddQueryParameterForMap("endpoint.Name");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("endpoint.Host");
		this.AddQueryParameterForReduce("endpoint.HostId");
		this.AddQueryParameterForReduce("endpoint.Name");
	}
}
