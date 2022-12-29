using FitDash.Core.Data;
using FitDash.Diet.Data.Contexts;
using FitDash.Diet.Domain.Entities;
using FitDash.Diet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly ReadModelSqlContext _context;

        public MealRepository(ReadModelSqlContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Meal> CreateAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            return meal;
        }

        public void Delete(Meal meal)
        {
            _context.Meals.Remove(meal);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Meal?> GetById(Guid id)
        {
            return await _context.Meals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Meal meal)
        {
            _context.Update(meal);
        }
    }
}
