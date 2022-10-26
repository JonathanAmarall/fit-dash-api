using FitDash.Api.Services;
using FitDash.Core.Mediator;
using FitDash.Workout.Application.Services;
using FitDash.Workout.Data.Repositories;
using FitDash.Workout.Domain.Repositories;
using MediatR;
using System.Reflection;

namespace FitDash.Api.Setup
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region Services
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();
            //builder.Services.AddAutoMapper();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ITokenService, TokenService>();
            #endregion

            #region Repositories
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IWorkoutRotineRepository, WorkoutRotineRepository>();
            #endregion

            #region Application Services
            services.AddScoped<IUserWorkoutRotinesService, UserWorkoutRotinesService>();
            #endregion

            #region MediatR
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            #endregion
        }
    }
}
