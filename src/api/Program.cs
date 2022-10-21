using FitDash.Workout.Data;
using FitDash.Workout.Data.Repositories;
using FitDash.Workout.Data.Seeders;
using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<WorkoutContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<IWorkoutRotineRepository, WorkoutRotineRepository>();

//builder.Services.AddHostedService<TimerBackgroundService>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<WorkoutContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

ApplySeeders(app.Services);
// Configure the HTTP request pipeline.
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