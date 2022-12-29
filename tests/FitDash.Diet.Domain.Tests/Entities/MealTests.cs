using FitDash.Diet.Domain.Tests.Fixture;
using static FitDash.Diet.Domain.Tests.Fixture.MealTestsFixture;

namespace FitDash.Diet.Domain.Tests.Entities
{
    [Collection(nameof(MealCollection))]
    public class MealTests
    {
        private readonly MealTestsFixture _fixture;

        public MealTests(MealTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Meal_Must_be_Instancied_With_Success()
        {
            // Arrange
            // Act
            var meal = _fixture.GenerateMealValid();

            // Assert
            Assert.NotNull(meal);
        }

        [Fact]
        public void Meal_Must_be_Calculated_Calories()
        {
            // Arrange
            var meal = _fixture.GenerateMealValid();
            // Act
            var mealCalories = meal.GetCalories();

            // Assert
            Assert.True(mealCalories > 0);
        }

    }
}
