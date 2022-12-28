using FitDash.Diet.Domain.Entities;

namespace FitDash.Diet.Domain.Tests.Entities
{
    public class BasalMetabolismTests
    {
        [Fact]
        public void BasalMetabolism_Should_Be_Instancied()
        {
            // Arrange
            // Act
            var bm = new BasalMetabolism(174, 90, 27, 1.5m, EGender.MALE);
            decimal dailyCalories = bm.DailyCalorieExpenditure();
            decimal idealWeight = bm.IdealWeight();

            // Assert
            Assert.NotNull(bm);
           
        }
    }
}
