using FitDash.Api.Models;
using FitDash.Api.Setup;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitDash.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppConfig _appSettings;
        private readonly UserManager<User> _userManager;

        public TokenService(
            IOptions<AppConfig> appSettings,
            UserManager<User> userManager
        )
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenJwtAsync(User user)
        {
            var identityClaims = new ClaimsIdentity();

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                identityClaims.AddClaim(new Claim(ClaimTypes.Role, role));

            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, user.Email));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiresHours),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidIn,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
