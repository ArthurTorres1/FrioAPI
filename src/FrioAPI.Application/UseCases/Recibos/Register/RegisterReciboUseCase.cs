using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;

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
            var nome = string.IsNullOrWhiteSpace(request.Nome);
            if (nome)
                throw new ArgumentException("");

            var equipamento = string.IsNullOrWhiteSpace(request.Equipamento);
            if (equipamento)
                throw new ArgumentException("O campo Equipamento é obrigatório.");

            var descricaoServico = string.IsNullOrWhiteSpace(request.DescricaoServico);
            if(descricaoServico)
                throw new ArgumentException("O campo Descrição do serviço' é obrigatório.");

            if (request.Total <= 0)
                throw new ArgumentException("O valor total deve er maior que zero");

            if (request.Data.Year < DateTime.UtcNow.Year)
                throw new Exception("Data inválida! O ano não pode ser anterior ao atual.");
        }
    }
}
