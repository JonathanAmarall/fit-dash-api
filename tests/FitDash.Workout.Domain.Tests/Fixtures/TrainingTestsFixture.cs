using Bogus;
using Bogus.DataSets;
using FitDash.Workout.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitDash.Workout.Domain.Tests.Fixtures
{
    public class TrainingTestsFixture : IDisposable
    {
        public Training GerarTrainoValido()
        {
            return new Training("Treino de Peito", "Até a falha", Core.Enums.EDifficulty.BEGINNER);
        }

        public void Dispose()
        {
        }
    }
}
