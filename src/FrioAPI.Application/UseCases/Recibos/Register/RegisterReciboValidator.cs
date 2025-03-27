using FluentValidation;
using FrioAPI.Communication.Requests;
using FrioAPI.Exception;

namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboValidator : AbstractValidator<RequestRegisterReciboJson>
    {
        public RegisterReciboValidator() 
        {
            RuleFor(recibo => recibo.NomeCliente).NotEmpty().WithMessage(ResourceErrorMessages.NOME_CLIENTE_OBRIGATORIO);
            RuleFor(recibo => recibo.Equipamento).NotEmpty().WithMessage(ResourceErrorMessages.EQUIPAMENTO_OBRIGATORIO);
            RuleFor(recibo => recibo.Cidade).NotEmpty().WithMessage(ResourceErrorMessages.CIDADE_OBRIGATORIO);
            RuleFor(recibo => recibo.UF).NotEmpty().WithMessage(ResourceErrorMessages.UF_OBRIGATORIO);
            RuleFor(recibo => recibo.DescricaoServico).NotEmpty().WithMessage(ResourceErrorMessages.DESCRICAO_SERVICO_OBRIGATORIO);
            RuleFor(recibo => recibo.Data)
                .NotEmpty().WithMessage(ResourceErrorMessages.DATA_OBRIGATORIA)
                .Must(data => data.Year >= DateTime.Now.Year).WithMessage(ResourceErrorMessages.DATA_RECIBO_ANOATUAL);
            RuleFor(recibo => recibo.Total)
                .GreaterThan(0).WithMessage(ResourceErrorMessages.TOTAL_MAIOR_QUE_ZERO);
        }
    }
}
