using todoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace todoAPI.DbContexts
{
    public class ListInfoContext : DbContext
    {
        public DbSet<List> Lists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ListInfo.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<List>()
                .HasData(
                new List("Laundry")
                {
                    Id = 1,
                },
                new List("Dishes")
                {
                    Id = 2,
                }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
