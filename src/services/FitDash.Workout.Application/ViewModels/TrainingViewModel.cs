
using FitDash.Core.DomainObjects.Enums;

namespace FitDash.Workout.Application.ViewModels
{
    public class TrainingViewModel
    {

        public TrainingViewModel(string title,  string? observations, EDifficulty? difficulty, List<Guid> exerciseIds)
        {
            Title = title;
            Observations = observations;
            Difficulty = difficulty;
            ExerciseIds = exerciseIds;
        }

        public string Title { get; set; }
        public string? Observations { get; set; }
        public EDifficulty? Difficulty { get; set; }
        public List<Guid> ExerciseIds { get; set; }

    }
}
