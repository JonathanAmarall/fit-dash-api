using FitDash.Core.DomainObjects.Enums;
using FitDash.Workout.Entities;
using System;
using Xunit;

namespace FitDash.Workout.Domain.Tests
{
    public class WorkoutRotineTests
    {
        public WorkoutRotine workoutRotineValid;
        public WorkoutRotineTests()
        {
            workoutRotineValid = new WorkoutRotine(Guid.NewGuid(), DateTime.Now, DateTime.Now, "Tomar muita água", true);
        }

        [Fact]
        public void WorkoutRotine_Deve_Ser_Valido()
        {
            // Arrange, Act, Assert (AAA)

            // Arrange = Arranjar, organizar, preparar, manipular
            var workoutRotine = workoutRotineValid;

            // Act
            workoutRotine.AddTraining(new Training("Treino de peito", null, EDifficulty.BEGINNER));

            // Assert
            Assert.True(workoutRotine.IsValid());
        }

        [Fact]
        public void WorkoutRotine_Deve_Ser_Inativado()
        {
            // Arrange, Act, Assert (AAA)

            // Arrange = Arranjar, organizar, preparar, manipular
            var workoutRotine = workoutRotineValid;

            // Act
            workoutRotine.InactiveWorkout();

            // Assert
            Assert.False(workoutRotine.Active);
        }
    }
}