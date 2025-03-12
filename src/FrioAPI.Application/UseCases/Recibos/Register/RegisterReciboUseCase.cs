using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;

namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboUseCase
    {
        public ResponseRegisteredReciboJson Execute(RequestRegisterReciboJson request)
        {
            return new ResponseRegisteredReciboJson();
        }
    }
}
