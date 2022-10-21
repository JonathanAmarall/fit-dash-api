using FitDash.Core.Mediator;
using FitDash.Workout.Application.Services;
using FitDash.Workout.Data;
using FitDash.Workout.Data.Repositories;
using FitDash.Workout.Data.Seeders;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Contexts
builder.Services.AddDbContext<WorkoutContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
#endregion

#region Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
#endregion

#region Repositories
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<IWorkoutRotineRepository, WorkoutRotineRepository>();
#endregion

#region Application Services
builder.Services.AddScoped<IUserWorkoutRotinesService, UserWorkoutRotinesService>();
#endregion

#region Identity 
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<WorkoutContext>()
.AddDefaultTokenProviders();
#endregion

#region MediatR
builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
#endregion

var app = builder.Build();

ApplySeeders(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ApplySeeders(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var exerciseRepository = scope.ServiceProvider.GetRequiredService<IExerciseRepository>();
        ExerciseSeed.CreateIfNotExist(exerciseRepository);
    }
}