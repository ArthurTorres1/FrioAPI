using System.Linq;
using AutoMapper;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Repositories;
using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Exception.ExceptionsBase;


namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboUseCase : IRegisterReciboUseCase
    {
        private readonly IRecibosWriteOnlyRepository _recibosRepository;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IMapper _mapper;

        public RegisterReciboUseCase(
            IRecibosWriteOnlyRepository repository,
            IUnidadeDeTrabalho unidadeDeTrabalho,
            IMapper mapper
            )
        {
            _recibosRepository = repository;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _mapper = mapper;
        }
        public async Task<ResponseRegisteredReciboJson> Execute(RequestRegisterReciboJson request) 
        {
            Validate(request);

            var entity = _mapper.Map<Recibo>(request);
            //salvando no banco de dados
            await _recibosRepository.Add(entity);
            await _unidadeDeTrabalho.Commit();

            return _mapper.Map<ResponseRegisteredReciboJson>(entity);
        }

        private void Validate(RequestRegisterReciboJson request) 
        {
            var validator = new RegisterReciboValidator();  
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
            
        }
    }
}
