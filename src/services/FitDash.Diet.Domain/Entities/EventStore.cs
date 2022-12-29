using FitDash.Core.Data;
using FitDash.Core.DomainObjects;

namespace FitDash.Diet.Domain.Entities
{
    public class EventStore: EntityBase, IAggregateRoot
    {
        public string EventName { get; set; }
        public string Metadata { get; set; }

        public EventStore(string eventName, string metadata)
        {
            EventName = eventName;
            Metadata = metadata;
        }

        public EventStore()
        {
        }
    }
}
