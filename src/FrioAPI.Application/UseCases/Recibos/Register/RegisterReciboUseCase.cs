using System.Linq;
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
        private readonly IRecibosRepository _recibosRepository;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        public RegisterReciboUseCase(IRecibosRepository repository,IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _recibosRepository = repository;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task<ResponseRegisteredReciboJson> Execute(RequestRegisterReciboJson request) 
        {
            Validate(request);

            var entity = new Recibo
            {
                NomeCliente = request.NomeCliente,
                Equipamento = request.Equipamento,
                DescricaoServico = request.DescricaoServico,
                Cidade = request.Cidade,
                UF = request.UF,
                Data = request.Data,
                Total = request.Total
            };
            await _recibosRepository.Add(entity);
            await _unidadeDeTrabalho.Commit();

            return new ResponseRegisteredReciboJson();
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
