using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Entities;

namespace FrioAPI.Application.UseCases.Recibos.GetById
{
    public interface IGetReciboByIdUseCase
    {
        Task<ResponseReciboJson> Execute(long id);
    }
}
