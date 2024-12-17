using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlackCats_Application
{
    public static class AssemblyReference
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration, string webRootPath)
        {
            configuration.GetSection("JWT");
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IContractService, ContractService>();

            return services;
        }

    }
}
