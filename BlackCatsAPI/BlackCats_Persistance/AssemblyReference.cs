using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackCats_Persistance
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(BCPSDbContext));
            services.AddDbContextPool<BCPSDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }
}
