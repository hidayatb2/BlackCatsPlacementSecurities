using BlackCats_Domain.Entities;
using BlackCats_Persistance.Seed;
using Microsoft.EntityFrameworkCore;
namespace BlackCats_Persistance 
{
    public class BCPSDbContext : DbContext
    {
        public BCPSDbContext(DbContextOptions<BCPSDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedUser());
        }
    }
}
