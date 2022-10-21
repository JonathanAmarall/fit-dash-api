using FitDash.Core.Events;

namespace FitDash.Core.DomainObjects

{
    public abstract class EntityBase
    {
        private List<Event> _notifications;
        public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();


        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; protected set; }
        
        public void AddEvent(Event eventItem)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications?.Remove(eventItem);
        }

        public void ClearEvents() => _notifications?.Clear();
    }
}