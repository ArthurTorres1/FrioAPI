using FrioAPI.Domain.Entities;

namespace FrioAPI.Domain.Repositories.Recibos
{
    public interface IRecibosRepository
    {
        Task Add(Recibo recibo);
        Task<List<Recibo>> GetAll();
    }
}
