using FitDash.Core.Events;
using FluentValidation;
using FluentValidation.Results;

namespace FitDash.Core.DomainObjects

{
    public abstract class EntityBase
    {
        public ValidationResult ValidationResult { get; protected set; }

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


        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}