namespace FitDash.Core.Events
{
    public class DomainEvent : Event
    {

        public DomainEvent(Guid aggregateId) 
        {
            AggregateId = aggregateId;
        }
    }



}
