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
            var connectionString = configuration.GetConnectionString("Connection-dev");

            var version = new Version(8, 0, 41);
            var serverVersion = new MySqlServerVersion(version);

            services.AddDbContext<FrioApiDBContext>(config => config.UseMySql(connectionString, serverVersion));
        }

    }
}
