using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlackCats_Application
{
    public static class AssemblyReference
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
