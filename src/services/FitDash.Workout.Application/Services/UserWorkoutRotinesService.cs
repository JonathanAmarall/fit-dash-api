using FitDash.Core.Events;
using FitDash.ViewModels;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Identity;

namespace FitDash.Workout.Application.Services
{
    public class UserWorkoutRotinesService : IUserWorkoutRotinesService
    {
        private readonly IWorkoutRotineRepository _workoutRotineRepository;
        private readonly ITrainingRepository _trainingRepository;

        public UserWorkoutRotinesService(IWorkoutRotineRepository workoutRotineRepository, ITrainingRepository trainingRepository)
        {
            _workoutRotineRepository = workoutRotineRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<ServiceResult> CreateRoutine(Guid userId, WorkoutRotineViewModel vm)
        {
            var workoutRotine = new WorkoutRotine(userId, vm.StartDate, vm.Validate, vm.Observations, vm.InactiveOnExpiration);

            foreach (var trainingId in vm.TrainingsId)
            {
                var training = await _trainingRepository.FindOneAsync(trainingId);
                if (training != null)
                {
                    workoutRotine.AddTraining(training);
                }
            }

            if (workoutRotine.Trainings?.Count == 0)
                return new ServiceResult(false, "Training must be informed!");

            await _workoutRotineRepository.CreateAsync(workoutRotine);

            if (workoutRotine.InactiveOnExpiration && workoutRotine.Validate != null)
                workoutRotine.AddEvent(new NewScheduleToRemoveWorkoutRotineEvent(workoutRotine.Id, (DateTime)workoutRotine.Validate, userId));

            workoutRotine.AddEvent(new NewWorkoutRotineCreatedEvent(workoutRotine.Id, workoutRotine.StartDate, workoutRotine.Validate, userId));

            await _workoutRotineRepository.UnitOfWork.Commit();

            return new ServiceResult(true, "Workout Rotine created successfully!", workoutRotine);
        }

        public void Dispose()
        {
            _trainingRepository.Dispose();
        }
    }

}
