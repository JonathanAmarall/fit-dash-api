using FitDash.Extensions;
using FitDash.ViewModels;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FitDash.Controllers.Workout
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkoutRotinesController : MainController
    {

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromBody] WorkoutRotineViewModel vm,
            [FromServices] IWorkoutRotineRepository workoutRotineRepository,
            [FromServices] ITrainingRepository trainingRepository,
            [FromServices] UserManager<User> userManager)
        {
            if (!ModelState.IsValid) return CustomReponse(vm);

            var user = await userManager.FindByIdAsync(vm.UserId);
            if (user == null)
                return BadRequest("User is not exits.");

            var workoutRotine = new WorkoutRotine(vm.UserId, vm.StartDate, vm.Validate, vm.Observations, vm.InactiveOnExpiration);

            foreach (var trainingId in vm.TrainingsId)
            {
                var training = await trainingRepository.FindOneAsync(trainingId);
                if (training != null)
                {
                    workoutRotine.AddTraining(training);
                }
            }

            if (workoutRotine.Trainings?.Count == 0)
                return BadRequest("Treinos informados inválidos");

            await workoutRotineRepository.CreateAsync(workoutRotine);
            await workoutRotineRepository.UnitOfWork.Commit();

            return Created($"WorkoutRotines/{workoutRotine.Id}", workoutRotine);
        }
    }
}
