using FitDash.Core.Data;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Workout.Data.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly WorkoutContext _context;

        public TrainingRepository(WorkoutContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(Training training)
        {
            await _context.Trainings.AddAsync(training);
        }

        public void Delete(Training training)
        {
            _context.Trainings.Remove(training);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Training?> FindOneAsync(Guid id)
        {
           return await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Training>> GetAllAsync()
        {
            return await _context.Trainings.ToListAsync();
        }

        public void Update(Training training)
        {
            _context.Trainings.Update(training);
        }
    }
}
