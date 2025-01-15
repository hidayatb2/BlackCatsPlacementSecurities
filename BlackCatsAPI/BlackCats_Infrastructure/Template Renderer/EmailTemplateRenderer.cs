using BlackCats_Application.Abstraction.TempleteRendrer;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Infrastructure.Template_Renderer
{
    public class EmailTemplateRenderer : IEmailTemplateRenderer
    {
        public async Task<string> RenderTemplateAsync(string templateName, object model)
        {

            try
            {
                var assemblyLocation = Assembly.GetExecutingAssembly().Location;
                //D:\Repository\TrainingRepository\DotNet\CoreApiArchitecture\CoreApiArchitecture.Infrastructure
                string assemblyDirectory = Path.GetDirectoryName(assemblyLocation)!;
                // infrastructure
                var templateFolder = Path.Combine(assemblyDirectory, "EmailTemplates");
                // Infrastructure/EmailTemplates
                var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(templateFolder)
                .UseMemoryCachingProvider()
                .EnableDebugMode()
                .Build();
                return await engine.CompileRenderAsync(templateName, model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
