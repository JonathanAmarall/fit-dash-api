using FitDash.Core.Data;
using FitDash.Diet.Domain.Entities;

namespace FitDash.Diet.Domain.Repositories
{
    public interface IBasalMetabolismRepository : IRepository<BasalMetabolism>
    {
        Task<BasalMetabolism?> GetById(Guid id);
        Task<BasalMetabolism> CreateAsync(BasalMetabolism basalMetabolism);
        void Delete(BasalMetabolism basalMetabolism);
        void Update(BasalMetabolism basalMetabolism);

        // Macronutrient.cs
        Task<Macronutrient?> GetMacronutrientById(Guid id);
        Task<Macronutrient> CreateMacronutrientAsync(Macronutrient macronutrient);
        void DeleteMacronutrient(Macronutrient macronutrient);
        void UpdateMacronutrient(Macronutrient macronutrient);
    }
}
