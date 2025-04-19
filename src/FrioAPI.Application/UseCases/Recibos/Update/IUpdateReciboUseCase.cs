using FrioAPI.Communication.Requests;

namespace FrioAPI.Application.UseCases.Recibos.Update
{
    public interface IUpdateReciboUseCase
    {
        Task Execute(long id, RequestReciboJson request);
    }
}
