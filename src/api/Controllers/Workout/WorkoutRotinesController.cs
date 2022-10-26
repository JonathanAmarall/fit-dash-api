using FitDash.Extensions;
using FitDash.ViewModels;
using FitDash.Workout.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitDash.Controllers.Workout
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkoutRotinesController : MainController
    {
        [HttpPost]
        public async Task<ActionResult> Post(
            [FromBody] WorkoutRotineViewModel vm,
            [FromServices] IUserWorkoutRotinesService userWorkoutRotinesService)
        {
            if (!ModelState.IsValid) return CustomReponse(vm);

            var res = await userWorkoutRotinesService.CreateRoutine(GetUserId(), vm);

            if (!res.Success)
                AddProcessingError(res.Message);

            return CustomReponse(res);
        }
    }
}
