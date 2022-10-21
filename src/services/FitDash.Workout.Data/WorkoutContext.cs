using FitDash.Core.Data;
using FitDash.Core.Events;
using FitDash.Core.Mediator;
using FitDash.Workout.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Workout.Data
{
    public class WorkoutContext : IdentityDbContext<User>, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public WorkoutContext(DbContextOptions<WorkoutContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<WorkoutRotine> WorkoutRotines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Event>();

            base.OnModelCreating(builder);
        }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublicEvents(this);

            return await SaveChangesAsync() > 0;
        }
    }
}