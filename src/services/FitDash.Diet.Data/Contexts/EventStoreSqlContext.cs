using FitDash.Core.Data;
using FitDash.Core.Messages.Events;
using FitDash.Diet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Contexts
{
    public class EventStoreSqlContext : DbContext, IUnitOfWork
    {
        public DbSet<EventStore> EventMetaData { get; set; }
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Event>();

            base.OnModelCreating(builder);
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
