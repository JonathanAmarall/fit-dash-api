using FitDash.Core.DomainObjects.Enums;
using FitDash.Diet.Domain.Entities;

namespace FitDash.Diet.Domain.Tests.Fixture
{
    public class BasalMetabolismTestsFixture : IDisposable
    {
        [CollectionDefinition(nameof(BasalMetabolismCollection))]
        public class BasalMetabolismCollection : ICollectionFixture<BasalMetabolismTestsFixture>
        {

        }

        public BasalMetabolism GenerateBasalMetabolismValid()
        {
            var bm = new BasalMetabolism(174, 90, 27, EActivityFactor.BEGINNER_TRAINING, EGender.MALE);
            return bm;
        }

        public BasalMetabolism GenerateBasalMetabolismInvalid()
        {
            var bm = new BasalMetabolism(100, 10, 27, EActivityFactor.BEGINNER_TRAINING, EGender.MALE);
            return bm;
        }

        public void Dispose()
        {

        }
    }
}
