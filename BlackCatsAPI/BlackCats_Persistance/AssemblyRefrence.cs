using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlackCats_Persistance
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BCPSDbContext>(options => options.UseMySql(configuration.GetConnectionString(nameof(BCPSDbContext)), ServerVersion.AutoDetect(configuration.GetConnectionString(nameof(BCPSDbContext)))));
            return services;
        }

    }
}
