namespace BlackCatsAPI
{
    public static  class AssemblyRefrence
    {

        public static IServiceCollection AddApiService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
