using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Repositories.Recibos;
using Microsoft.EntityFrameworkCore;

namespace FrioAPI.Infrastructure.DataAccess.Repositories
{
    internal class RecibosRepository : IRecibosReadOnlyRepository, IRecibosWriteOnlyRepository, IRecibosUpdateOnlyRepository
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
        //só é chamado pela interface de leitura
        async Task<Recibo?> IRecibosReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Recibos.AsNoTracking().FirstOrDefaultAsync(recibo => recibo.Id == id);
        }

        async Task<Recibo?> IRecibosUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Recibos.FirstOrDefaultAsync(recibo => recibo.Id == id);
        }

        public void Update(Recibo recibo)
        {
            _dbContext.Recibos.Update(recibo);
        }

        public async Task<List<Recibo>> FilterByMonth(DateOnly data)
        {
            //pega o primeiro dia do mes
            var dataDeInicio = new DateTime(year: data.Year, month: data.Month, day: 1).Date;
            //pega o total de dias no mes
            var diasNoMes = DateTime.DaysInMonth(year: data.Year, month: data.Month);
            //pega o ultimo dia do mes
            var dataDeTermino = new DateTime(year: data.Year, month: data.Month, day: diasNoMes, hour: 23, minute: 59, second: 59);
            return await _dbContext
                .Recibos
                .AsNoTracking()
                .Where(recibo => recibo.Data >= dataDeInicio && recibo.Data <= dataDeTermino)
                .OrderBy(recibo => recibo.Data)
                .ThenBy(recibo => recibo.NomeCliente)
                .ToListAsync();
        }
    }
}
