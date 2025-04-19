using FrioAPI.Domain.Entities;

namespace FrioAPI.Domain.Repositories.Recibos
{
    public interface IRecibosWriteOnlyRepository
    {
        Task Add(Recibo recibo);
        /// <summary>
        /// Esta função retorna TRUE se o processo de remover o recibo der sucesso se não retorna falso.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);
    }
}
