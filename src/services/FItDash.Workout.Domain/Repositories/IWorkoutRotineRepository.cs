using FitDash.Core.Data;
using FitDash.Workout.Entities;

namespace FitDash.Workout.Domain.Repositories
{
    public interface IWorkoutRotineRepository : IRepository<WorkoutRotine>
    {
        Task CreateAsync(WorkoutRotine workoutRotine);
    }
    

}
