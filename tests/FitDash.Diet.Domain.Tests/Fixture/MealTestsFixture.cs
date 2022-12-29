using FitDash.Diet.Domain.Entities;

namespace FitDash.Diet.Domain.Tests.Fixture
{
    public class MealTestsFixture : IDisposable
    {
        [CollectionDefinition(nameof(MealCollection))]
        public class MealCollection : ICollectionFixture<MealTestsFixture>
        {

        }

        public Meal GenerateMealValid()
        {
            return new Meal("Arroz tipo 1", 100, "g", 2.69m, 28.17m, 0.28m, Enums.EMealType.LUNCH);
        }

        public Meal GenerateMealInvalid()
        {
            return new Meal("Arroz tipo 1", 0, "g", 0, 0, 0, Enums.EMealType.LUNCH);
        }

        public void Dispose()
        {
        }
    }
}
