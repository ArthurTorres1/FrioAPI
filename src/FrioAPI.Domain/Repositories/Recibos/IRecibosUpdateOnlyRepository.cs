using FrioAPI.Domain.Entities;

namespace FrioAPI.Domain.Repositories.Recibos
{
    public interface IRecibosUpdateOnlyRepository
    {
        Task<Recibo?> GetById(long id);
        void Update(Recibo recibo);
    }
}
