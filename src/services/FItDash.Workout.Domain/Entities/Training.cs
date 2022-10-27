using FitDash.Core.Data;
using FitDash.Core.DomainObjects;
using FitDash.Core.Enums;
using FluentValidation;
using FluentValidation.Results;

namespace FitDash.Workout.Entities
{
    public class Training : EntityBase, IAggregateRoot
    {

        private IList<Exercise> exerciseList;
        private IList<WorkoutRotine> workoutRotineList;
        public Training(string title, string observations, EDifficulty? difficulty)
        {
            Title = title;
            Observations = observations;
            Difficulty = difficulty;

            exerciseList = new List<Exercise>();
            workoutRotineList = new List<WorkoutRotine>();
        }

        public string Title { get; private set; }
        public string Observations { get; private set; }
        public EDifficulty? Difficulty { get; private set; }

        public ICollection<Exercise> Exercises { get => exerciseList; }
        public ICollection<WorkoutRotine> WorkoutRotines { get => workoutRotineList; }

        public void AddExercise(Exercise exercise)
        {
            exerciseList.Add(exercise);
        }

        public override bool IsValid()
        {
            ValidationResult = new TrainingValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class TrainingValidation : AbstractValidator<Training>
    {
        public TrainingValidation()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Por favor, verifique se o título foi informado")
                .Length(3, 150).WithMessage("O Título deve ter entre 3 e 150 caracteres");

            RuleFor(e => e.Observations)
               .Length(0, 200).WithMessage("Observação deve ter no máximo 200 caracteres");

            RuleFor(e => e.Exercises.Count)
                .NotNull().WithMessage("Exercício é obrigatório")
                .GreaterThan(0);
        }
    }

}