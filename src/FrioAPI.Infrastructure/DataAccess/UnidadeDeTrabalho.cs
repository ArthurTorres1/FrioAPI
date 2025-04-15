using FrioAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
