using AutoMapper;
using FrioAPI.Application.UseCases.Recibos.Register;
using FrioAPI.Communication.Requests;
using FrioAPI.Domain.Repositories;
using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Exception;
using FrioAPI.Exception.ExceptionsBase;

namespace FrioAPI.Application.UseCases.Recibos.Update
{
    public class UpdateReciboUseCase : IUpdateReciboUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IRecibosUpdateOnlyRepository _repository;

        public UpdateReciboUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, IRecibosUpdateOnlyRepository repository)
        {
            _mapper = mapper;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _repository = repository;
        }
        public async Task Execute(long id, RequestReciboJson request)
        {
            Validate(request);

            var recibo = await _repository.GetById(id);

            if (recibo == null)
                throw new NotFoundException(ResourceErrorMessages.RECIBO_NAO_ENCONTRADO);

            _mapper.Map(request, recibo);
            _repository.Update(recibo);

            await _unidadeDeTrabalho.Commit();
        }

        private void Validate(RequestReciboJson request)
        {
            var validator = new ReciboValidator();
            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
