using FitDash.Diet.Domain.Tests.Fixture;
using static FitDash.Diet.Domain.Tests.Fixture.BasalMetabolismTestsFixture;

namespace FitDash.Diet.Domain.Tests.Entities
{
    [Collection(nameof(BasalMetabolismCollection))]
    public class BasalMetabolismTests
    {
        private readonly BasalMetabolismTestsFixture _fixture;

        public BasalMetabolismTests(BasalMetabolismTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void BasalMetabolism_Should_Be_Instancied()
        {
            // Arrange
            // Act
            var bm = _fixture.GenerateBasalMetabolismInvalid();

            // Assert
            Assert.NotNull(bm);
        }

        [Fact]
        public void BasalMetabolism_Must_Be_Calculated_DailyCalorieExpenditure()
        {
            // Arrange
            var bm = _fixture.GenerateBasalMetabolismInvalid();

            // Act
            decimal dailyCalories = bm.DailyCalorieExpenditure();

            // Assert
            Assert.True(dailyCalories > 0);
        }

        [Fact]
        public void BasalMetabolism_Must_Be_Calculated_Ideal_Weight()
        {
            // Arrange
            var bm = _fixture.GenerateBasalMetabolismInvalid();

            // Act
            decimal idealWeight = bm.IdealWeight();

            // Assert
            Assert.True(idealWeight > 0);
        }

        [Fact]
        public void BasalMetabolism_Must_Be_Instancied_Macronutrient()
        {
            // Arrange
            var bm = _fixture.GenerateBasalMetabolismInvalid();

            // Act
            var macro = bm.Macronutrient;

            // Assert
            Assert.NotNull(macro);
        }
    }
}
