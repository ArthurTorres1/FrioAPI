using FrioAPI.Domain.Repositories;
using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Infrastructure.DataAccess;
using FrioAPI.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FrioAPI.Infrastructure
{
    public static class DepedencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepostories(services);
            AddDbContext(services, configuration);
        }

        private static void AddRepostories(IServiceCollection services)
        {
            services.AddScoped<IRecibosReadOnlyRepository, RecibosRepository>();
            services.AddScoped<IRecibosWriteOnlyRepository, RecibosRepository>();
            services.AddScoped<IRecibosUpdateOnlyRepository, RecibosRepository>();
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            // Busca a connection string da variável de ambiente configurada no Render
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_PROD")
                                   ?? configuration.GetConnectionString("Connection-dev");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("A Connection String não foi configurada.");
            }

            services.AddDbContext<FrioApiDBContext>(options =>
                options.UseSqlServer(connectionString));
        }

    }
}
