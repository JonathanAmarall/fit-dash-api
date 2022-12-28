using FitDash.Core.Data;
using FitDash.Core.DomainObjects;

namespace FitDash.Diet.Domain.Entities
{
    public class Meal : EntityBase, IAggregateRoot
    {
        public Meal(string description, decimal quantity, string baseUnit, decimal protein, decimal carbs, decimal fat, EMealType mealType)
        {
            Description = description;
            Quantity = quantity;
            BaseUnit = baseUnit;
            Protein = protein;
            Carbs = carbs;
            Fat = fat;
            MealType = mealType;
        }

        public string Description { get; set; }
        public decimal Quantity { get; private set; }
        public string BaseUnit { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Carbs { get; private set; }
        public decimal Fat { get; private set; }

        public EMealType MealType { get; private set; }

        public decimal GetCalories()
        {
            return Protein + Carbs + Fat;
        }
    }
}
