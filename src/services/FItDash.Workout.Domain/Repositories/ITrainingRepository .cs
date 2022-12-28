using FitDash.Core.Data;
using FitDash.Workout.Entities;

namespace FitDash.Workout.Domain.Repositories
{
    public interface ITrainingRepository : IRepository<Training>
    {
        Task CreateAsync(Training training);
        void Update(Training training);
        void Delete(Training training);
        Task<Training?> FindOneAsync(Guid id);
        Task<List<Training>> GetAllAsync();
    }
}
