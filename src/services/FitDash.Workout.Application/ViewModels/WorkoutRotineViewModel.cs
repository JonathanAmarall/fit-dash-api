using System.ComponentModel.DataAnnotations;

namespace FitDash.ViewModels
{
    public class WorkoutRotineViewModel
    {
        public WorkoutRotineViewModel(DateTime? startDate, DateTime? validate, string? observations,  bool inactiveOnExpiration, string userId, List<Guid> trainingsId)
        {
            StartDate = startDate;
            Validate = validate;
            Observations = observations;
            InactiveOnExpiration = inactiveOnExpiration;
            UserId = userId;
            TrainingsId = trainingsId;
        }

        [Required]
        public List<Guid> TrainingsId { get; set; }
        [Required]
        public bool InactiveOnExpiration { get; set; }
        [Required]
        public string UserId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? Validate { get; set; }
        public string? Observations { get; set; }
    }
}
