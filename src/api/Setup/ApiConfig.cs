using FitDash.Api.Data;
using FitDash.Diet.Data.Contexts;
using FitDash.Workout.Data;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Api.Setup
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
          
            #region Contexts

            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<WorkoutContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<ReadModelSqlContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DietDbConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<EventStoreSqlContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EventStoreDbConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


            #endregion
        }

    }
}