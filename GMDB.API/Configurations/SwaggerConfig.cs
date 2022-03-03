using GMDB.API.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GMDB.API.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("gmdb", new OpenApiInfo
                {
                    Version = "1.0.0.0",
                    Title = "GMDB API"
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
