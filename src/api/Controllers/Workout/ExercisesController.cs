using FitDash.Extensions;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitDash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : MainController
    {
        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> Get([FromServices] IExerciseRepository exerciseRepository) =>
            Ok(await exerciseRepository.GetAllAsync());


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Exercise?>> GetById(Guid id, [FromServices] IExerciseRepository exerciseRepository)
        {
            var exercise = await exerciseRepository.FindOneAsync(id);
            if (exercise == null)
                AddProcessingError("Exercise is not exists.");

            return CustomReponse(exercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> Post(
            [FromBody] Exercise exercise,
            [FromServices] IExerciseRepository exerciseRepository)
        {
            if (!ModelState.IsValid) return CustomReponse(exercise);

            await exerciseRepository.CreateAsync(exercise);
            await exerciseRepository.UnitOfWork.Commit();

            return CreatedAtAction(nameof(GetById), new { Id = exercise.Id }, exercise);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Exercise exercise, [FromServices] IExerciseRepository exerciseRepository)
        {
            if (!ModelState.IsValid) return CustomReponse(exercise);
            var exerciseExistent = await exerciseRepository.FindOneAsync(id);
            if (exerciseExistent == null)
                AddProcessingError("Exercise is not exists.");

            exerciseExistent.Update(exercise.Name, exercise.UrlVideo);
            exerciseRepository.Update(exerciseExistent);
            await exerciseRepository.UnitOfWork.Commit();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, [FromServices] IExerciseRepository exerciseRepository)
        {
            var exerciseExistent = await exerciseRepository.FindOneAsync(id);
            if (exerciseExistent == null)
                return NotFound();

            exerciseRepository.Delete(exerciseExistent);
            await exerciseRepository.UnitOfWork.Commit();

            return NoContent();
        }

    }
}
