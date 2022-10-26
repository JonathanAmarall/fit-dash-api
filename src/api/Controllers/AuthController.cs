using FitDash.Api.Models;
using FitDash.Api.Services;
using FitDash.Api.ViewModels;
using FitDash.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitDash.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : MainController
    {
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(
            AuthenticateUserViewModel model,
            [FromServices] UserManager<User> userManager,
            [FromServices] SignInManager<User> signInManager,
            [FromServices] ITokenService tokenService)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null) AddProcessingError("Email or password invalid.");

            if (!user.EmailConfirmed) AddProcessingError("Email is not confirmed.");

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (result.Succeeded)
            {
                var token = await tokenService.GenerateTokenJwtAsync(user);
                await signInManager.SignInAsync(user, false);
                return CustomReponse(new
                {
                    Token = token,
                    UserName = user.UserName,
                    Email = user.Email,
                });
            }
            AddProcessingError("Email or password invalid.");
            return CustomReponse();
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(
           RegisterUserViewModel model,
           [FromServices] ITokenService tokenService,
           [FromServices] UserManager<User> userManager)
        {
            if (model.ConfirmPassword != model.Password)
            {
                AddProcessingError("Password and ConfirmPassowrd does not match.");
                return CustomReponse();
            }

            var newUser = new User(model.UserName, model.Email, model.BirthDate, model.Weight, model.Hight, true);

            var result = await userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                var tokenJwt = await tokenService.GenerateTokenJwtAsync(newUser);
                
                // TODO: Send email with confirmation Token
                // var tokenOfConfirmationEmail = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                // await SendEmailConfirmationTokenAsync(tokenOfConfirmationEmail, newUser);

                return CustomReponse(new
                {
                    Token = tokenJwt,
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                });
            }

            foreach (var error in result.Errors)
            {
                AddProcessingError(error.Description);
            }

            return CustomReponse();
        }
    }
}
