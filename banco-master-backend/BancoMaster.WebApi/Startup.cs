using BancoMaster.Dominio.Config;
using BancoMaster.Infra.IOC;
using BancoMaster.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BancoMaster.WebApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Configurações

            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            var _conf = new ConfigAmbiente();
            Configuration.Bind("ConfigAmbiente", _conf);
            services.AddSingleton(_conf);

            services.AddControllers()
                    .AddJsonOptions(options => {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

            services.AddSwaggerConfiguration();

            Dependencia.RegistrarDependencias(services);

            #endregion

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();  //

            app.UseHttpsRedirection();

            app.UseRouting();

            //
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            //

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
