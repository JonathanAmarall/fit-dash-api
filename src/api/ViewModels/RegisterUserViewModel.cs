namespace FitDash.Api.ViewModels
{
    public class RegisterUserViewModel
    {
      
        public RegisterUserViewModel(string userName, string email, string confirmPassword, string password, DateTime birthDate, float weight, float hight)
        {
            UserName = userName;
            Email = email;
            ConfirmPassword = confirmPassword;
            Password = password;
            BirthDate = birthDate;
            Weight = weight;
            Hight = hight;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public float Hight { get; set; }
    }

    public class AuthenticateUserViewModel
    {
        public AuthenticateUserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }

}
