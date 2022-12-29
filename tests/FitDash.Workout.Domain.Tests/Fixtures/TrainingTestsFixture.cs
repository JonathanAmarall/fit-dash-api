using FitDash.Core.DomainObjects.Enums;
using FitDash.Workout.Entities;
using System;

namespace FitDash.Workout.Domain.Tests.Fixtures
{
    public class TrainingTestsFixture : IDisposable
    {
        public Training GerarTrainoValido()
        {
            return new Training("Treino de Peito", "Até a falha", EDifficulty.BEGINNER);
        }

        public void Dispose()
        {
        }
    }
}
