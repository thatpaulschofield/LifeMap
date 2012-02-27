using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EventStore;
using EventStore.Dispatcher;
using NServiceBus;

namespace LifeMap.Common.Infrastructure
{
    public sealed class NServiceBusCommitDispatcher : IDispatchCommits
    {
        private readonly Lazy<IBus> _busResolver;
        private const string AggregateIdKey = "AggregateId";
        private const string CommitVersionKey = "CommitVersion";
        private const string EventVersionKey = "EventVersion";
        private const string BusPrefixKey = "Bus.";

        public NServiceBusCommitDispatcher(Lazy<IBus> busResolver)
        {
            _busResolver = busResolver;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Dispatch(Commit commit)
        {
            for (var i = 0; i < commit.Events.Count; i++)
            {
                try
                {
                    var eventMessage = commit.Events[i];
                    var busMessage = eventMessage.Body;
                    //AppendHeaders(busMessage, commit.Headers);
                    //AppendHeaders(busMessage, eventMessage.Headers);
                    AppendVersion(commit, i);

                    //if (busMessage.IsEvent())
                        _busResolver.Value.Publish(new[] {busMessage});
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
            foreach (var header in commit.Headers.Select(header => header.Value))
            {
                if (header.IsCommand())
                    _busResolver.Value.Send(header);
            }
        }

        private static void AppendHeaders(IMessage message, IEnumerable<KeyValuePair<string, object>> headers)
        {
            headers = headers.Where(x => x.Key.StartsWith(BusPrefixKey));
            foreach (var header in headers)
            {
                var key = header.Key.Substring(BusPrefixKey.Length);
                var value = (header.Value ?? string.Empty).ToString();
                message.SetHeader(key, value);
            }
        }
        private static void AppendVersion(Commit commit, int index)
        {
            try
            {
                var busMessage = commit.Events[index].Body as IMessage;
                busMessage.SetHeader(AggregateIdKey, commit.StreamId.ToString());
                busMessage.SetHeader(CommitVersionKey, commit.StreamRevision.ToString());
                busMessage.SetHeader(EventVersionKey, GetSpecificEventVersion(commit, index).ToString());
            }
            catch (Exception)
            {
            }
        }
        private static int GetSpecificEventVersion(Commit commit, int index)
        {
            // e.g. (StreamRevision: 120) - (5 events) + 1 + (index @ 4: the last index) = event version: 120
            return commit.StreamRevision - commit.Events.Count + 1 + index;
        }
    }
}
