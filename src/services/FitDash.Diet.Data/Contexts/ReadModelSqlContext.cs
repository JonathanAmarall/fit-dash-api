using FitDash.Diet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Diet.Data.Contexts
{
    public class ReadModelSqlContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Macronutrient> Macronutrients { get; set; }
        public DbSet<BasalMetabolism> BasalMetabolisms { get; set; }

        public ReadModelSqlContext(DbContextOptions<ReadModelSqlContext> options)
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
