using FitDash.Api.Services;
using FitDash.Core.Mediator;
using FitDash.Core.Messages.Events;
using FitDash.Diet.Data.Repositories;
using FitDash.Diet.Domain.CommandHandlers;
using FitDash.Diet.Domain.Commands;
using FitDash.Diet.Domain.EventHandlers;
using FitDash.Diet.Domain.Repositories;
using FitDash.Workout.Application.Services;
using FitDash.Workout.Data.Repositories;
using FitDash.Workout.Domain.Repositories;
using FluentValidation.Results;
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
            services.AddScoped<ITokenService, TokenService>();
            #endregion

            #region Repositories
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IWorkoutRotineRepository, WorkoutRotineRepository>();

            services.AddScoped<IBasalMetabolismRepository, BasalMetabolismRepository>(); 
            services.AddScoped<IEventStoreRepository, EventStoreRepository>(); 
            #endregion

            #region Application Services
            services.AddScoped<IUserWorkoutRotinesService, UserWorkoutRotinesService>();
            #endregion

            #region MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<NewBasalMetabolismsCreatedEvent>, NewBasalMetabolismsCreatedEventHandler>();
            #endregion

            #region Handlers
            services.AddScoped<IRequestHandler<CreateBasalMetabolismCommand, ValidationResult>, CreateBasalMetabolismCommandHandler>();
            #endregion
        }
    }
}
