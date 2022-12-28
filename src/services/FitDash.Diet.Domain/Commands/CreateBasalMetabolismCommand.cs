using FitDash.Core.Messages;
using FitDash.Diet.Domain.Enums;
using FitDash.Diet.Domain.Validators;

namespace FitDash.Diet.Domain.Commands
{
    public class CreateBasalMetabolismCommand : Command
    {
        public CreateBasalMetabolismCommand(int height, int weight, int yearsOld, decimal activityFactor, EGender gender)
        {
            Height = height;
            Weight = weight;
            YearsOld = yearsOld;
            ActivityFactor = activityFactor;
            Gender = gender;
        }

        public int Height { get; private set; }
        public int Weight { get; private set; }
        public int YearsOld { get; private set; }
        public decimal ActivityFactor { get; private set; }
        public EGender Gender { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateBasalMetabolismCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
