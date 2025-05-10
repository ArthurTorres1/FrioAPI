using FrioAPI.Communication.Responses;

namespace FrioAPI.Application.UseCases.ViaCep
{
    public interface IBuscaEnderecoViaCep
    {
        Task<ResponseViaCep?> BuscaCep(string cep);
    }
}
