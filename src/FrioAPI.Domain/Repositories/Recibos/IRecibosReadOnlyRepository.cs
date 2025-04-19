using FrioAPI.Domain.Entities;

namespace FrioAPI.Domain.Repositories.Recibos
{
    public interface IRecibosReadOnlyRepository
    {
        Task<List<Recibo>> GetAll();
        Task<Recibo?> GetById(long id);
        Task<List<Recibo>> FilterByMonth(DateOnly data);
    }
}
