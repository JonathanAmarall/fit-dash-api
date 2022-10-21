using Microsoft.AspNetCore.Identity;

namespace FitDash.Workout.Entities
{
    public class User : IdentityUser
    {
        private readonly IList<WorkoutRotine> workoutRoutineList;
        public User(DateTime birthDate, float weight, float height)
        {
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

            workoutRoutineList = new List<WorkoutRotine>();    
        }

        public DateTime BirthDate { get; private set; }
        public float Weight { get; private set; }
        public float Height { get; private set; }

        public ICollection<WorkoutRotine> WorkoutRotines{ get => workoutRoutineList; }

        public int GetYearsOld()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }
    }
}