using FrioAPI.Communication.Responses;

namespace FrioAPI.Application.UseCases.Recibos.GetAll
{
    public interface IGetAllReciboUseCase
    {
        Task<ResponseRecibosJson> Execute();
    }
}
