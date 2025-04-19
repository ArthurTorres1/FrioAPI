
using FrioAPI.Domain.Repositories;
using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Exception;
using FrioAPI.Exception.ExceptionsBase;

namespace FrioAPI.Application.UseCases.Recibos.Delete
{
    public class DeleteReciboUseCase : IDeleteReciboUseCase
    {
        private readonly IRecibosWriteOnlyRepository _repository;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public DeleteReciboUseCase(
            IRecibosWriteOnlyRepository repository, 
            IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _repository = repository;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task Execute(long id)
        {
            var result = await _repository.Delete(id);
            if (result == false)
                throw new NotFoundException(ResourceErrorMessages.RECIBO_NAO_ENCONTRADO);
            
            await _unidadeDeTrabalho.Commit();
        }
    }
}
