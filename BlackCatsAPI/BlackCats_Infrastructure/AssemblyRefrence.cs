using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackCats_Infrastructure
{
    public static  class AssemblyRefrence
    {

        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

    }
}
