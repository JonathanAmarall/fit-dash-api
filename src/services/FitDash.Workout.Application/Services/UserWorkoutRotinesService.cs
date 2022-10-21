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

            await _workoutRotineRepository.CreateAsync(workoutRotine);

            if (workoutRotine.InactiveOnExpiration && workoutRotine.Validate != null)
                workoutRotine.AddEvent(new NewScheduleToRemoveWorkoutRotineEvent(workoutRotine.Id, (DateTime)workoutRotine.Validate, workoutRotine.UserId));

            workoutRotine.AddEvent(new NewWorkoutRotineCreatedEvent(workoutRotine.Id, workoutRotine.StartDate, workoutRotine.Validate, workoutRotine.UserId));

            await _workoutRotineRepository.UnitOfWork.Commit();

            return new ServiceResult(true, "Workout Rotine created successfully!", workoutRotine);
        }

        public void Dispose()
        {
            _trainingRepository.Dispose();
            _userManager.Dispose();
            _workoutRotineRepository.Dispose();
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
