using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Repositories.Recibos;

namespace FrioAPI.Infrastructure.DataAccess.Repositories
{
    internal class RecibosRepository : IRecibosRepository
    {
        public void Add(Recibo recibo)
        {
            var dbContext = new FrioApiDBContext();

            dbContext.Recibos.Add(recibo);
            dbContext.SaveChanges();
        }
    }
}
