using FitDash.Core.Data;
using FitDash.Core.DomainObjects;
using FitDash.Core.Enums;

namespace FitDash.Workout.Entities
{
    public class Training : EntityBase, IAggregateRoot
    {
        private IList<Exercise> exerciseList;
        private IList<WorkoutRotine> workoutRotineList;
        public Training(string title, string observations, EDifficulty? difficulty)
        {
            Title = title;
            Observations = observations;
            Difficulty = difficulty;

            exerciseList = new List<Exercise>();
            workoutRotineList = new List<WorkoutRotine>();
        }

        public string Title { get; private set; }
        public string Observations { get; private set; }
        public EDifficulty? Difficulty { get; private set; }

        public ICollection<Exercise> Exercises { get => exerciseList; }
        public ICollection<WorkoutRotine> WorkoutRotines { get => workoutRotineList; }


        public void AddExercise(Exercise exercise)
        {
            exerciseList.Add(exercise);
        }
    }
  
}