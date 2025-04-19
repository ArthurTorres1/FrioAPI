namespace FrioAPI.Application.UseCases.Recibos.Delete
{
    public interface IDeleteReciboUseCase
    {
        Task Execute(long id);
    }
}
