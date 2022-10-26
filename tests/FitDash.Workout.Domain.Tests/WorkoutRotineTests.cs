using FitDash.Workout.Entities;
using System;
using Xunit;

namespace FitDash.Workout.Domain.Tests
{
    public class WorkoutRotineTests
    {
        [Fact]
        public void WorkoutRotine_Deve_Ser_Instanciado()
        {
            // Arrange, Act, Assert (AAA)

            // Arrange = Arranjar, organizar, preparar, manipular
            var workoutRotine = new WorkoutRotine(Guid.NewGuid(), DateTime.Now, DateTime.Now, "Tomar muita água", true);

            // Act
            workoutRotine.AddTraining(new Training("Treino de peito", null, Core.Enums.EDifficulty.BEGINNER));

            // Assert
            Assert.NotNull(workoutRotine);
        }

        [Fact]
        public void WorkoutRotine_Deve_Ser_Inativado()
        {
            // Arrange, Act, Assert (AAA)

            // Arrange = Arranjar, organizar, preparar, manipular
            var workoutRotine = new WorkoutRotine(Guid.NewGuid(), DateTime.Now, DateTime.Now, "Tomar muita água", true);

            // Act
            workoutRotine.InactiveWorkout();

            // Assert
            Assert.False(workoutRotine.Active);
        }
    }
}