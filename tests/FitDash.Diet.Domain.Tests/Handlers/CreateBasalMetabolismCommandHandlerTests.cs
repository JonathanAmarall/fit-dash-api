using FitDash.Core.Mediator;
using FitDash.Diet.Domain.CommandHandlers;
using FitDash.Diet.Domain.Repositories;
using FitDash.Diet.Domain.Tests.Fixture;
using FluentAssertions;
using Moq;
using static FitDash.Diet.Domain.Tests.Fixture.CreateBasalMetabolismCommandTestsFixture;

namespace FitDash.Diet.Domain.Tests.Handlers
{

    [Collection(nameof(CreateBasalMetabolismCollection))]
    public class CreateBasalMetabolismCommandHandlerTests
    {
        private readonly CreateBasalMetabolismCommandTestsFixture _fixture;

        public CreateBasalMetabolismCommandHandlerTests(CreateBasalMetabolismCommandTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CreateBasalMetabolismCommandHandler_Valid()
        {
            // Arrange
            var basalMetabolismRepository = new Mock<IBasalMetabolismRepository>();
            basalMetabolismRepository.Setup(c => c.UnitOfWork.Commit().Result).Returns(true);
            
            var mediatorHandler = new Mock<IMediatorHandler>();
            var handler = new CreateBasalMetabolismCommandHandler(basalMetabolismRepository.Object, mediatorHandler.Object);
            var command = _fixture.Valid();

            // Act
            var result = handler.Handle(command, CancellationToken.None).Result;

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void CreateBasalMetabolismCommandHandler_Invalid()
        {
            // Arrange
            var basalMetabolismRepository = new Mock<IBasalMetabolismRepository>();
            basalMetabolismRepository.Setup(c => c.UnitOfWork.Commit().Result).Returns(true);

            var mediatorHandler = new Mock<IMediatorHandler>();
            var handler = new CreateBasalMetabolismCommandHandler(basalMetabolismRepository.Object, mediatorHandler.Object);
            var command = _fixture.Invalid();

            // Act
            var result = handler.Handle(command, CancellationToken.None).Result;

            // Assert
            result.IsValid.Should().BeFalse("Deve estar inválido.");
        }
    }
}
