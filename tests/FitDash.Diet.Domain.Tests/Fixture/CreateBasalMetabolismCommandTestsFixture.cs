using FitDash.Core.DomainObjects.Enums;
using FitDash.Diet.Domain.Commands;

namespace FitDash.Diet.Domain.Tests.Fixture
{
    public class CreateBasalMetabolismCommandTestsFixture
    {
        [CollectionDefinition(nameof(CreateBasalMetabolismCollection))]
        public class CreateBasalMetabolismCollection : ICollectionFixture<CreateBasalMetabolismCommandTestsFixture>
        {

        }

        public CreateBasalMetabolismCommand Valid()
        {
            return new CreateBasalMetabolismCommand(150, 70, 33, EActivityFactor.SEDENTARY, EGender.FEMALE);
        }

        public CreateBasalMetabolismCommand Invalid()
        {
            return new CreateBasalMetabolismCommand(-10, 20, 1, EActivityFactor.SEDENTARY, EGender.FEMALE);
        }
    }
}
