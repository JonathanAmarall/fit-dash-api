using FitDash.Core.Data;
using FitDash.Workout.Entities;

namespace FitDash.Workout.Domain.Repositories
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        Task CreateAsync(Exercise exercise);
        Task<Exercise?> FindOneAsync(Guid id);
        Task<List<Exercise>> GetAllAsync();
        void Delete(Exercise exercise);
        void Update(Exercise exercise);
        bool Exist(string name);
        bool Exist(Guid id);
    }
}
