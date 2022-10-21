using FitDash.Core.Data;
using FitDash.Core.DomainObjects;

namespace FitDash.Workout.Entities
{
    public class Exercise : EntityBase, IAggregateRoot
    {
        public Exercise(string name, string urlVideo)
        {
            Name = name;
            UrlVideo = urlVideo;
        }

        public string Name { get; private set; }
        public string UrlVideo { get; private set; }

        public ICollection<Training>? Trainings { get; set; }

        public void Update(string name, string urlVideo)
        {
            Name = name;
            UrlVideo = urlVideo;
            UpdateAt = DateTime.Now;
        }

    }
}