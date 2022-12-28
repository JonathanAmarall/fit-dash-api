using FitDash.Diet.Domain.Commands;
using FluentValidation;

namespace FitDash.Diet.Domain.Validators
{
    public class CreateBasalMetabolismCommandValidator : AbstractValidator<CreateBasalMetabolismCommand>
    {
        public CreateBasalMetabolismCommandValidator()
        {
            RuleFor(x => x.YearsOld)
                .NotNull()
                .GreaterThan(10)
                .WithMessage("Years Old must be greater than 10.");

            RuleFor(x => x.Weight)
                .NotNull()
                .GreaterThan(40)
                .WithMessage("Weight must be greater than 40 kg");

            RuleFor(x => x.Height)
              .NotNull()
              .GreaterThan(120)
              .WithMessage("Height must be greater than 120 cm");

            RuleFor(e => e.ActivityFactor)
             .IsInEnum().WithMessage("Active Factor must be valid value");

            RuleFor(e => e.Gender)
           .IsInEnum().WithMessage("Gender must be valid value");
        }
    }
  
}
