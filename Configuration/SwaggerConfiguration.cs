using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace JiraComunicacao.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Jira API",
                    Description = "API de Comunicacao Jira"
                });
            });
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "api/docs/{documentName}/swagger.json"; });
            app.UseSwaggerUI(

                options =>
                {
                    options.RoutePrefix = "api/docs";
                    options.DefaultModelExpandDepth(2);
                    options.DefaultModelRendering(ModelRendering.Example);
                    options.DefaultModelsExpandDepth(-1);
                    options.DisplayOperationId();
                    options.DisplayRequestDuration();
                    options.DocExpansion(DocExpansion.None);
                    options.EnableDeepLinking();
                    options.EnableFilter();
                    options.MaxDisplayedTags(30);
                    options.ShowExtensions();
                    options.EnableValidator();

                    options.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put,
                        SubmitMethod.Delete);
                });
            return app;
        }
    }
}
