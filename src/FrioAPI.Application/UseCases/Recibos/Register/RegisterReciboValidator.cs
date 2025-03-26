using FluentValidation;
using FrioAPI.Communication.Requests;

namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboValidator : AbstractValidator<RequestRegisterReciboJson>
    {
        public RegisterReciboValidator() 
        {
            RuleFor(recibo => recibo.NomeCliente).NotEmpty().WithMessage("O campo (Nome) é obrigatório.");
            RuleFor(recibo => recibo.Equipamento).NotEmpty().WithMessage("O campo (Equipamento) é obrigatório.");
            RuleFor(recibo => recibo.Cidade).NotEmpty().WithMessage("O campo (Endereço) é obrigatório.");
            RuleFor(recibo => recibo.UF).NotEmpty().WithMessage("O campo (UF) é obrigatório.");
            RuleFor(recibo => recibo.DescricaoServico).NotEmpty().WithMessage("O campo (Descricao Serviço) é obrigatório.");
            RuleFor(recibo => recibo.Data)
                .NotEmpty().WithMessage("O campo (Data) é obrigatório.")
                .Must(data => data.Year >= DateTime.Now.Year).WithMessage("Não foi possível gerar um recibo anterior ao ano atual.");
            RuleFor(recibo => recibo.Total)
                .NotEmpty().WithMessage("O campo (Total) não pode ser vazio")
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero ");
        }
    }
}
