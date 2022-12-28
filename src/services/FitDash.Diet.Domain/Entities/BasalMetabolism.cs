using FitDash.Core.Data;
using FitDash.Core.DomainObjects;
using FitDash.Diet.Domain.Enums;

namespace FitDash.Diet.Domain.Entities
{
    public class BasalMetabolism : EntityBase, IAggregateRoot
    {
        public BasalMetabolism(int height, int weight, int yearsOld, decimal activityFactor, EGender gender)
        {
            Height = height;
            Weight = weight;
            YearsOld = yearsOld;
            ActivityFactor = activityFactor;
            Gender = gender;

            Macronutrients = new Macronutrient(Weight);
        }

        public int Height { get; private set; }
        public int Weight { get; private set; }
        public int YearsOld { get; private set; }
        public decimal ActivityFactor { get; private set; }
        public Macronutrient Macronutrients { get; private set; }
        public EGender Gender { get; private set; }


        public decimal DailyCalorieExpenditure()
        {
            decimal idealWeight = 65;

            var dce = ActivityFactor * (66.47m + (13.75m * idealWeight) + (5m * Height) - (6.8m * YearsOld));

            return dce;
        }

        public decimal IdealWeight()
        {
            decimal idealWeight = 0;

            if (Gender == EGender.MALE)
            {
                idealWeight = Convert.ToDecimal(Math.Pow(1.74, 2)) * 21.5m;
            }

            if (Gender == EGender.FEMALE)
            {
                idealWeight = Convert.ToDecimal(Math.Pow(Height, 2)) * 22.5m;
            }

            return idealWeight / 100;
        }

    }
}
