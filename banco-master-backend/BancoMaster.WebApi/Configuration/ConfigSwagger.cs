using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.WebApi.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ConfigSwagger
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Teste Desenvolvedor .NET - Banco Master",
                    Version = "v1",
                    Contact = new OpenApiContact() { Name = "Glauber Q Maximiano", Email = "glauber.maximiano@gmail.com" },
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Teste Desenvolvedor .NET - Banco Master");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
