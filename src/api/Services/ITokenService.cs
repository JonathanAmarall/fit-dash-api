using FitDash.Api.Models;

namespace FitDash.Api.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenJwtAsync(User user);
    }
}