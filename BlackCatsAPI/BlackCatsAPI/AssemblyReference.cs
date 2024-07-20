namespace BlackCatsAPI
{
    public static  class AssemblyReference
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
