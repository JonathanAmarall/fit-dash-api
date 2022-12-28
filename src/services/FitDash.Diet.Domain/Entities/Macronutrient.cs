using FitDash.Core.DomainObjects;

namespace FitDash.Diet.Domain.Entities
{

    public class Macronutrient : EntityBase
    {
        public Macronutrient(decimal weight)
        {
            Protein = weight * 4;
            Carbs = weight * 4;
            Fat = weight * 9;

            Calories = Protein + Carbs + Fat;
        }

        public decimal Protein { get; private set; }
        public decimal Carbs { get; private set; }
        public decimal Fat { get; private set; }

        public decimal Calories { get; private set; }

        public void ApplyCaloricDeficit(decimal value)
        {

        }

        public void ApplyCaloricSurplus(decimal value)
        {

        }

    }

}
