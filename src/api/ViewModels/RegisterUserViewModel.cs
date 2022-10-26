namespace FitDash.Api.ViewModels
{
    public class RegisterUserViewModel
    {
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
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
