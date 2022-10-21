using FitDash.Core.Data;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Workout.Data
{
    public class WorkoutContext : IdentityDbContext<User>, IUnitOfWork
    {
        public DbSet<WorkoutRotine> WorkoutRotines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }


        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}