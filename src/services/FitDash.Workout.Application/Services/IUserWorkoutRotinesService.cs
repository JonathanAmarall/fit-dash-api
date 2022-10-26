using FitDash.ViewModels;

namespace FitDash.Workout.Application.Services
{
    public interface IUserWorkoutRotinesService : IDisposable
    {
        Task<ServiceResult> CreateRoutine(Guid userId, WorkoutRotineViewModel vm);
    }
}