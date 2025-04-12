using FrioAPI.Application.UseCases.Recibos.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FrioAPI.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegisterReciboUseCase, RegisterReciboUseCase>();
        }
    }
}
