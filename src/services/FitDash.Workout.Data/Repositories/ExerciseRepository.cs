using FitDash.Core.Data;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Workout.Data.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly WorkoutContext _context;

        public ExerciseRepository(WorkoutContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(Exercise exercise)
        {
            await _context.AddAsync(exercise);
        }

        public void Delete(Exercise exercise)
        {
           _context.Exercises.Remove(exercise);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public bool Exist(string name)
        {
           return _context.Exercises.Any(x => x.Name.ToUpper() == name.ToUpper());
        }

        public bool Exist(Guid id)
        {
            return _context.Exercises.Any(x => x.Id == id);
        }


        public async Task<Exercise?> FindOneAsync(Guid id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public void Update(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
        }
    }
}
