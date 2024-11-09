using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.Services;
using BlackCats_Infrastructure.Identity;
using BlackCats_Infrastructure.Storage_Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackCats_Infrastructure
{
    public static  class AssemblyRefrence
    {

        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services,IConfiguration configuration,string webRootPath)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton <IStorageService>(new LocalStorage(webRootPath));
            services.AddSingleton<IContextService,ContextService>();

            return services;
        }

    }
}
