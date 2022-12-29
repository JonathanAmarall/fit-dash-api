using FitDash.Diet.Domain.Tests.Fixture;
using static FitDash.Diet.Domain.Tests.Fixture.CreateBasalMetabolismCommandTestsFixture;

namespace FitDash.Diet.Domain.Tests.Commands
{
    [Collection(nameof(CreateBasalMetabolismCollection))]
    public class CreateBasalMetabolismCommandTests
    {
        private readonly CreateBasalMetabolismCommandTestsFixture _fixture;

        public CreateBasalMetabolismCommandTests(CreateBasalMetabolismCommandTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CreateBasalMetabolismCommandTests_Valid()
        {
            // Arrange
            var command = _fixture.Valid();

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(0, command.ValidationResult?.Errors.Count);
        }


        [Fact]
        public void CreateBasalMetabolismCommandTests_Invalid()
        {
            // Arrange
            var command = _fixture.Invalid();

            // Act
            command.IsValid();

            // Assert
            Assert.NotEqual(0, command.ValidationResult?.Errors.Count);
        }
    }
}
