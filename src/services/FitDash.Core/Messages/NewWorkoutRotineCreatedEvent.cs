namespace FitDash.Core.Events
{
    public class NewWorkoutRotineCreatedEvent : DomainEvent
    {
        public DateTime? StartDate { get;  set; }
        public DateTime? Validate { get;  set; }
        public string UserId { get; set; }


        public NewWorkoutRotineCreatedEvent(Guid aggregateId) : base(aggregateId)
        {

        }
    }
}
