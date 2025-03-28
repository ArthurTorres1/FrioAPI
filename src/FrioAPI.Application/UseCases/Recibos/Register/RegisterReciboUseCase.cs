using System.Linq;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Entities;
using FrioAPI.Exception.ExceptionsBase;


namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboUseCase
    {
        public ResponseRegisteredReciboJson Execute(RequestRegisterReciboJson request)
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
