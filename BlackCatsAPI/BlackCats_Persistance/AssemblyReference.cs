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
            services.AddDbContext<BCPSDbContext>(options =>
            {
                options.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }
}
