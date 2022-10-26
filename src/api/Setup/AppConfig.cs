namespace FitDash.Api.Setup
{
    public class AppConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string ValidIn { get; set; }
        public int ExpiresHours { get; set; }
    }
}
