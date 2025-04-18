using FrioAPI.Domain.Entities;

namespace FrioAPI.Domain.Repositories.Recibos
{
    public interface IRecibosWriteOnlyRepository
    {
        Task Add(Recibo recibo);
    }
}
