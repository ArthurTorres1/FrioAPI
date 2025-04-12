using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrioAPI.Infrastructure
{
    public static class DepedencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        { 
            services.AddScoped<IRecibosRepository, RecibosRepository>();
        }
    }
}
