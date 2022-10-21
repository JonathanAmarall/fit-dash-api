
using FitDash.Core.Enums;

namespace FitDash.Workout.Application.ViewModels
{
    public class TrainingViewModel
    {

        public TrainingViewModel(string title, DateTime dueDate, string? observations, EDifficulty? difficulty, List<Guid> exerciseIds)
        {
            Title = title;
            DueDate = dueDate;
            Observations = observations;
            Difficulty = difficulty;
            ExerciseIds = exerciseIds;
        }

        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string? Observations { get; set; }
        public EDifficulty? Difficulty { get; set; }
        public List<Guid> ExerciseIds { get; set; }

    }
}
