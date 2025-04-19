using FrioAPI.Application.AutoMapper;
using FrioAPI.Application.UseCases.Recibos.Delete;
using FrioAPI.Application.UseCases.Recibos.GetAll;
using FrioAPI.Application.UseCases.Recibos.GetById;
using FrioAPI.Application.UseCases.Recibos.Register;
using FrioAPI.Application.UseCases.Recibos.Reports.Excel;
using FrioAPI.Application.UseCases.Recibos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace FrioAPI.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterReciboUseCase, RegisterReciboUseCase>();
            services.AddScoped<IGetAllReciboUseCase, GetAllReciboUseCase>();
            services.AddScoped<IGetReciboByIdUseCase, GetReciboByIdUseCase>();
            services.AddScoped<IUpdateReciboUseCase, UpdateReciboUseCase>();
            services.AddScoped<IDeleteReciboUseCase, DeleteReciboUseCase>();
            services.AddScoped<IGenerateRecibosReportExcelUseCase, GenerateRecibosReportExcelUseCase>();
        }
    }
}
