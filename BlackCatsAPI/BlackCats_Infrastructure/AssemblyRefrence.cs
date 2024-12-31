using BlackCats_Application.Abstraction.IEmailService;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.Abstraction.TempleteRendrer;
using BlackCats_Application.Services;
using BlackCats_Infrastructure.Email_Services;
using BlackCats_Infrastructure.Identity;
using BlackCats_Infrastructure.Storage_Services;
using BlackCats_Infrastructure.Template_Renderer;
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
            services.Configure<MailJetOptions>(options =>
            {
                options.ApiKey = configuration.GetSection("MailJetOptions:ApiKey").Value!;
                options.ApiSecret = configuration.GetSection("MailJetOptions:ApiSecret").Value!;
                options.FromEmail = configuration.GetSection("MailJetOptions:FromEmail").Value!;
                options.DisplayName = configuration.GetSection("MailJetOptions:DisplayName").Value!;
            });
            services.AddSingleton<IEmailService, MailJetService>();
            services.AddScoped<IEmailTemplateRenderer, EmailTemplateRenderer>();

            return services;
        }

    }
}
