using FitDash.Core.Events;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitDash.Core.Messages.Events
{
    public abstract class Event : Message, INotification
    {
        public Guid EventStoreId { get; set; }
        public string EventName { get; set; }
        public string Metadata { get; set; }

        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        public Event(Guid eventStoreId, string eventName, string metadata)
        {
            EventStoreId = eventStoreId;
            EventName = eventName;
            Metadata = metadata;
            Timestamp = DateTime.Now;
        }
    }

}
