using IMDB_Clone_API.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IMDB_Clone_API.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("imdb-clone", new OpenApiInfo
                {
                    Version = "1.0.0.0",
                    Title = "IMDB Clone API"
                });
                options.EnableAnnotations();
                options.CustomOperationIds(operationIdSelector => operationIdSelector.ActionDescriptor.RouteValues["action"]);
                options.DocumentFilter<SwaggerDocumentFilter>();
                options.UseAllOfToExtendReferenceSchemas();
                options.UseAllOfForInheritance();
                options.UseOneOfForPolymorphism();
            });
            return services;
        }
    }
}
