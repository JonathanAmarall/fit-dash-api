using FitDash.Core.Data;
using FitDash.Core.DomainObjects;

namespace FitDash.Workout.Entities
{
    public class WorkoutRotine : EntityBase, IAggregateRoot
    {
        private readonly IList<Training>? _trainingList;

        public WorkoutRotine(Guid userId, DateTime? startDate, DateTime? validate, string? observations, bool inactiveOnExpiration)
        {
            UserId = userId;
            StartDate = startDate;
            Validate = validate;
            Observations = observations;
            InactiveOnExpiration = inactiveOnExpiration;
            Active = true;

            _trainingList = new List<Training>();
        }

        public DateTime? StartDate { get; private set; }
        public DateTime? Validate { get; private set; }
        public string? Observations { get; private set; }
        public bool Active { get; private set; }
        public bool InactiveOnExpiration { get; private set; }

        // EF Rel.
        public ICollection<Training>? Trainings { get => _trainingList; }

        public Guid UserId { get; private set; }


        public void AddTraining(Training training)
        {
            _trainingList?.Add(training);
        }

        public void InactiveWorkout()
        {
            Active = false;
            UpdateAt = DateTime.Now;
        }
    }

}
