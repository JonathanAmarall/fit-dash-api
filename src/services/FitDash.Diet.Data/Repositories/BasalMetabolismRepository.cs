using FitDash.Core.Data;
using FitDash.Diet.Data.Contexts;
using FitDash.Diet.Domain.Entities;
using FitDash.Diet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Repositories
{
    public class BasalMetabolismRepository : IBasalMetabolismRepository
    {
        private readonly ReadModelSqlContext _context;

        public BasalMetabolismRepository(ReadModelSqlContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<BasalMetabolism> CreateAsync(BasalMetabolism basalMetabolism)
        {
            await _context.AddAsync(basalMetabolism);
            return basalMetabolism;
        }

        public Task<Macronutrient> CreateMacronutrientAsync(Macronutrient macronutrient)
        {
            throw new NotImplementedException();
        }

        public void Delete(BasalMetabolism basalMetabolism)
        {
            _context.BasalMetabolisms.Remove(basalMetabolism);
        }

        public void DeleteMacronutrient(Macronutrient macronutrient)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<BasalMetabolism?> GetById(Guid id)
        {
            return await _context.BasalMetabolisms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Macronutrient?> GetMacronutrientById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(BasalMetabolism basalMetabolism)
        {
            _context.BasalMetabolisms.Update(basalMetabolism);
        }

        public void UpdateMacronutrient(Macronutrient macronutrient)
        {
            throw new NotImplementedException();
        }
    }
}
