using BlackCats.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats.Persistence
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<BlackCatsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SmartLibraryConnection")!));
            return services;
        }

    }
}
