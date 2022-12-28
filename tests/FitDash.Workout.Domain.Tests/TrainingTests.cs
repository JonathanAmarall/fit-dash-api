using FitDash.Core.Enums;
using FitDash.Workout.Entities;
using Xunit;

namespace FitDash.Workout.Domain.Tests
{
    public class TrainingTests
    {
        [Fact(DisplayName = "Novo Treino Válido")]
        [Trait("Categoria", "Novo Treino válido")]
        public void Training_Deve_Ser_Instanciado()
        {
            // Arrange
            var training = new Training("Treino de Peito", "Até a falha", EDifficulty.BEGINNER);

            // Act
            training.AddExercise(new Exercise("Supino", ""));

            // Assert
            Assert.NotNull(training);
            Assert.True(training.IsValid());
            Assert.Equal(1, training.Exercises.Count);
        }
    }
}
