using System.Linq;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using FrioAPI.Exception.ExceptionsBase;

namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboUseCase
    {
        public ResponseRegisteredReciboJson Execute(RequestRegisterReciboJson request)
        {
            Validate(request);
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
