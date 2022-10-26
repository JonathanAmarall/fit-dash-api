using Microsoft.AspNetCore.Identity;

namespace FitDash.Api.Models
{
    public class User : IdentityUser<Guid>
    {
        public User(string userName, string email, DateTime birthDate, float weight, float height, bool emailConfirmed) :
            base(userName: userName)
        {
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            BirthDate = birthDate;

            Email = email;
            EmailConfirmed = emailConfirmed;
        }

        public DateTime BirthDate { get; private set; }
        public float Weight { get; private set; }
        public float Height { get; private set; }


        public int GetYearsOld()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }
    }
}
