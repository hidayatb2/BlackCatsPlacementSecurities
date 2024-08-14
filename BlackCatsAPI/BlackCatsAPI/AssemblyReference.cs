namespace BlackCatsAPI
{
    public static  class AssemblyReference
    {

        public static IServiceCollection AddApiService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(opt =>
            {
                opt.AddPolicy("BCPSWebClientPolicy", options =>
                {
                    options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials();
                });

            });

            return services;
        }
    }
}
