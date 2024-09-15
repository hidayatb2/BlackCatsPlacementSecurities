using BlackCats_Domain.Entities;
using BlackCats_Persistance.Seed;
using Microsoft.EntityFrameworkCore;
namespace BlackCats_Persistance.Data
{
    public class BCPSDbContext : DbContext
    {
        public BCPSDbContext(DbContextOptions<BCPSDbContext> options) : base(options)
        {
        }

        public DbSet<User> USERS { get; set; }

        public DbSet<Employee> EMPLOYEES { get; set; }

        public DbSet<Client> CLIENTS { get; set; }

        public DbSet<Wages> WAGES { get; set; }

        public DbSet<Contract> CONTRACTS { get; set; }

        public DbSet<AppFile> APPFILES { get; set; }





        #region SeedValue Function
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedUser());
        }
        #endregion
    }
}
