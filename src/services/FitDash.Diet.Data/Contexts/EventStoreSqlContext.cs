using FitDash.Core.Events;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Contexts
{
    public class EventStoreSqlContext : DbContext
    {
        public DbSet<Event> EventMetaData { get; set; }

        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options)
      : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
