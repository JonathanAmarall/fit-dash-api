using FitDash.Core.DomainObjects;

namespace FitDash.Diet.Domain.Entities
{

    public class Macronutrient : EntityBase
    {
        protected Macronutrient() { }
        public Macronutrient(decimal weight)
        {
            Protein = (weight * 2) * 4;
            Carbs = (weight * 3) * 4;
            Fat = (weight * 1) * 9;

            Calories = Protein + Carbs + Fat;
        }

        public decimal Protein { get; private set; }
        public decimal Carbs { get; private set; }
        public decimal Fat { get; private set; }

        public decimal Calories { get; private set; }

        // EF Rel.
        public Guid BasalMetabolismId { get; private set; }
        public BasalMetabolism BasalMetabolism { get; private set; }

        public void ApplyCaloricDeficit(decimal value)
        {

        }

        public void ApplyCaloricSurplus(decimal value)
        {

        }

    }

}
