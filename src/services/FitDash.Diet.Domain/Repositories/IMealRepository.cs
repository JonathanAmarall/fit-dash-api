using FitDash.Core.Data;
using FitDash.Diet.Domain.Entities;

namespace FitDash.Diet.Domain.Repositories
{
    public interface IMealRepository : IRepository<Meal>
    {
        Task<Meal?> GetById(Guid id);
        Task<Meal> CreateAsync(Meal meal);
        void Delete(Meal meal);
        void Update(Meal meal);
    }
}
