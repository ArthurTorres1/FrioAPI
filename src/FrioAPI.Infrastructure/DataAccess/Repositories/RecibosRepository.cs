using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Repositories.Recibos;

namespace FrioAPI.Infrastructure.DataAccess.Repositories
{
    internal class RecibosRepository : IRecibosRepository
    {
        private readonly FrioApiDBContext _dbContext;
        public RecibosRepository(FrioApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Recibo recibo)
        {
            _dbContext.Recibos.Add(recibo);
        }
    }
}
