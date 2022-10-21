namespace FitDash.Core.Events
{
    public class NewWorkoutRotineCreatedEvent : Event
    {
        public DateTime? StartDate { get; private set; }
        public DateTime? Validate { get; private set; }
        public string UserId { get; private set; }

        public NewWorkoutRotineCreatedEvent(Guid workoutRotineId, DateTime? startDate, DateTime? validate, string userId)
        {
            AggregateId = workoutRotineId;
            StartDate = startDate;
            Validate = validate;
            UserId = userId;
        }
    }

    public class NewScheduleToRemoveWorkoutRotineEvent : Event
    {
        public DateTime DueDate { get; private set; }
        public string UserId { get; private set; }

        public NewScheduleToRemoveWorkoutRotineEvent(Guid workoutRotineId, DateTime dueDate, string userId)
        {
            AggregateId = workoutRotineId;
            DueDate = dueDate;
            UserId = userId;
        }
    }
}
