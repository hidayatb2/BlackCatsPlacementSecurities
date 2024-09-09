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

        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Wages> Wages { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<AppFile> AppFiles { get; set; }





        #region SeedValue Function
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedUser());
        }
        #endregion
    }
}
