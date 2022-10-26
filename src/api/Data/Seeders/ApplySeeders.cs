using FitDash.Workout.Data.Seeders;
using FitDash.Workout.Domain.Repositories;

namespace FitDash.Api.Data.Seeders
{
    public static class ApplySeeders
    {

        public static void WorkoutSeeders(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var exerciseRepository = scope.ServiceProvider.GetRequiredService<IExerciseRepository>();
                ExerciseSeed.CreateIfNotExist(exerciseRepository);
            }
        }


    }
}
