using FitDash.ViewModels;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Identity;

namespace FitDash.Workout.Application.Services
{
    public class UserWorkoutRotinesService
    {
        private readonly IWorkoutRotineRepository _workoutRotineRepository;
        private readonly ITrainingRepository _trainingRepository;
        private readonly UserManager<User> _userManager;

        public UserWorkoutRotinesService(IWorkoutRotineRepository workoutRotineRepository, ITrainingRepository trainingRepository, UserManager<User> userManager)
        {
            _workoutRotineRepository = workoutRotineRepository;
            _trainingRepository = trainingRepository;
            _userManager = userManager;
        }

        public async Task<ServiceResult> CreateRoutine(WorkoutRotineViewModel vm)
        {

            var user = await _userManager.FindByIdAsync(vm.UserId);
            if (user == null)
                return new ServiceResult(false, "User is not exits.");

            var workoutRotine = new WorkoutRotine(vm.UserId, vm.StartDate, vm.Validate, vm.Observations, vm.InactiveOnExpiration);

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

            if (workoutRotine.InactiveOnExpiration)
            {
                // TODO: create function in background service for inative this Workoutrotine
            }

            await _workoutRotineRepository.CreateAsync(workoutRotine);
            if (await _workoutRotineRepository.UnitOfWork.Commit())
            {
                // TODO: Emitir evento
                return new ServiceResult(true, "Workout Rotine created successfully!", workoutRotine);
            }

            return new ServiceResult(false, "Persistence is failed!", workoutRotine);
        }

    }

    public class ServiceResult
    {
        public ServiceResult(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

}
