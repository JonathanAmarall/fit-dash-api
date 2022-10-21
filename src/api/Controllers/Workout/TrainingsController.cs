using FitDash.Extensions;
using FitDash.ViewModels;
using FitDash.Workout.Application.ViewModels;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitDash.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrainingsController : MainController
    {
        [HttpGet]
        public async Task<ActionResult<List<Training>>> Get([FromServices] ITrainingRepository trainingRepository) =>
            Ok(await trainingRepository.GetAllAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Training>> GetById(Guid id, [FromServices] ITrainingRepository trainingRepository)
        {
            var training = await trainingRepository.FindOneAsync(id);
            if (training == null)
                AddProcessingError("Training is not exits");

            return CustomReponse(training);
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromBody] TrainingViewModel vm,
            [FromServices] ITrainingRepository trainingRepository,
            [FromServices] IExerciseRepository exerciseRepository)
        {
            if (!ModelState.IsValid) return CustomReponse(vm);

            if (vm.ExerciseIds.Count == 0)
            {
                AddProcessingError("É preciso adicionar ao menos um Exercício ao treinamento!");
                return CustomReponse();
            }

            var training = new Training(vm.Title, vm.Observations, vm.Difficulty);

            foreach (var exerciseId in vm.ExerciseIds)
            {
                var exercise = await exerciseRepository.FindOneAsync(exerciseId);
                if (exercise != null)
                    training.AddExercise(exercise);
                else
                    AddProcessingError("Exercicio informado não existe.");
            }

            if (OperationValid())
            {
                await trainingRepository.CreateAsync(training);
                await trainingRepository.UnitOfWork.Commit();
                // TODO: Ajustar retorno
                return Created(new Uri(Url.Link("api/v1/Training", new { Id = training.Id })), training);
            }

            return CustomReponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Training training, [FromServices] ITrainingRepository trainingRepository)
        {
            if (!ModelState.IsValid) return CustomReponse(training);

            var trainingExistent = await trainingRepository.FindOneAsync(id);
            if (trainingExistent == null)
                AddProcessingError("Treino não encontrado");

            if (training.Id != id)
                return BadRequest();

            if (OperationValid())
            {
                trainingRepository.Update(training);
                await trainingRepository.UnitOfWork.Commit();

                return NoContent();
            }

            return CustomReponse();
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, [FromServices] ITrainingRepository trainingRepository)
        {
            var trainingExistent = await trainingRepository.FindOneAsync(id);
            if (trainingExistent == null)
                AddProcessingError("Treino não encontrado");

            if (OperationValid())
            {
                trainingRepository.Delete(trainingExistent);
                await trainingRepository.UnitOfWork.Commit();
            }

            return CustomReponse();
        }

    }
}
