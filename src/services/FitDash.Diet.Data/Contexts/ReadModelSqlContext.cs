using FitDash.Core.Data;
using FitDash.Core.Mediator;
using FitDash.Core.Messages.Events;
using FitDash.Diet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Contexts
{
    public class ReadModelSqlContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ReadModelSqlContext(DbContextOptions<ReadModelSqlContext> options, IMediatorHandler mediatorHandler)
       : base(options)
        {
            Database.EnsureCreated();
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Macronutrient> Macronutrients { get; set; }
        public DbSet<BasalMetabolism> BasalMetabolisms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Event>();

            builder.Entity<BasalMetabolism>()
                .HasOne(m => m.Macronutrient)
                .WithOne(bm => bm.BasalMetabolism)
                .HasForeignKey<Macronutrient>(x => x.BasalMetabolismId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublicEvents(this);

            return await SaveChangesAsync() > 0;
        }
    }
}
