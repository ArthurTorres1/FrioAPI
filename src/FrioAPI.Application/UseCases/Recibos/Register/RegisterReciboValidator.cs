using FluentValidation;
using FrioAPI.Communication.Requests;

namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboValidator : AbstractValidator<RequestRegisterReciboJson>
    {
        public RegisterReciboValidator() 
        {
            RuleFor(recibo => recibo.Nome).NotEmpty().WithMessage("O campo (Nome) é obrigatório.");
            RuleFor(recibo => recibo.Equipamento).NotEmpty().WithMessage("O campo (Equipamento) é obrigatório.");
            RuleFor(recibo => recibo.Endereco).NotEmpty().WithMessage("O campo (Endereço) é obrigatório.");
        }
    }
}
