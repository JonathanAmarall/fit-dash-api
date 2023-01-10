using FitDash.Diet.Domain.Tests.Fixture;
using FluentAssertions;
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
            command.IsValid().Should().BeTrue();
            command.ValidationResult?.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void CreateBasalMetabolismCommandTests_Invalid()
        {
            // Arrange
            var command = _fixture.Invalid();

            // Act
            bool isValid = command.IsValid();

            // Assert
            isValid.Should().BeTrue();
            command.ValidationResult?.Errors.Should().HaveCount(0);
        }
    }
}
