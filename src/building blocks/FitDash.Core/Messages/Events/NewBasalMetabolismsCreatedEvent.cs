using FitDash.Core.DomainObjects.Enums;

namespace FitDash.Core.Messages.Events
{
    public class NewBasalMetabolismsCreatedEvent : Event
    {
        public NewBasalMetabolismsCreatedEvent(int height, int weight, int yearsOld, EActivityFactor activityFactor, EGender gender)
        {
            Height = height;
            Weight = weight;
            YearsOld = yearsOld;
            ActivityFactor = activityFactor;
            Gender = gender;
        }

        public int Height { get; private set; }
        public int Weight { get; private set; }
        public int YearsOld { get; private set; }
        public EActivityFactor ActivityFactor { get; private set; }
        public EGender Gender { get; private set; }

    }
}
