using FrioAPI.Domain.Repositories;

namespace FrioAPI.Infrastructure.DataAccess
{
    internal class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private readonly FrioApiDBContext _dbContext;
        public UnidadeDeTrabalho(FrioApiDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task Commit() => await _dbContext.SaveChangesAsync(); 
    }
}
