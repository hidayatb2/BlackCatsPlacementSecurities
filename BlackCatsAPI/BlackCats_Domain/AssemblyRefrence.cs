using Microsoft.Extensions.DependencyInjection;

namespace BlackCats_Domain
{
    public static class AssemblyRefrence
    {

        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            return services;
        }

    }
}
