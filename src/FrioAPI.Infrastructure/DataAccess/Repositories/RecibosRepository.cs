﻿using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Repositories.Recibos;
using Microsoft.EntityFrameworkCore;

namespace FrioAPI.Infrastructure.DataAccess.Repositories
{
    internal class RecibosRepository : IRecibosReadOnlyRepository, IRecibosWriteOnlyRepository
    {
        private readonly FrioApiDBContext _dbContext;
        public RecibosRepository(FrioApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Recibo recibo)
        {
            await _dbContext.Recibos.AddAsync(recibo);
        }

        public async Task<bool> Delete(long id)
        {
           var result = await _dbContext.Recibos.FirstOrDefaultAsync(recibo => recibo.Id == id);
           if(result is null)
                return false;

           _dbContext.Recibos.Remove(result);
            return true;
        }

        public async Task<List<Recibo>> GetAll()
        {
            //select
            return await _dbContext.Recibos.AsNoTracking().ToListAsync();
        }

        public async Task<Recibo?> GetById(long id)
        {
            return await _dbContext.Recibos.AsNoTracking().FirstOrDefaultAsync(recibo => recibo.Id == id);
        }
    }
}
