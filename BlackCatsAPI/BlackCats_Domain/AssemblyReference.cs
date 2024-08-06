using Microsoft.Extensions.DependencyInjection;

namespace BlackCats_Domain
{
    public static class AssemblyReference
    {

        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            return services;
        }

    }
}
