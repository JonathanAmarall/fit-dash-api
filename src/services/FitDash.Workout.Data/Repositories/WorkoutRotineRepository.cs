using FitDash.Core.Data;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;

namespace FitDash.Workout.Data.Repositories
{
    public class WorkoutRotineRepository : IWorkoutRotineRepository
    {
        private readonly WorkoutContext _context;

        public WorkoutRotineRepository(WorkoutContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(WorkoutRotine workoutRotine)
        {
            await _context.AddAsync(workoutRotine);
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
