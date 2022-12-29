using FitDash.Core.Messages.Events;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Contexts
{
    public class EventStoreSqlContext : DbContext
    {

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
