using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Infrastructure.DataAccess;
using FrioAPI.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrioAPI.Infrastructure
{
    public static class DepedencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepostories(services);
            AddDbContext(services);
        }
        private static void AddRepostories(IServiceCollection services)
        {
            services.AddScoped<IRecibosRepository, RecibosRepository>();
        }
        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<FrioApiDBContext>();
        }

    }
}
