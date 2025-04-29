using FrioAPI.Communication.Responses;
using FrioAPI.Exception;
using FrioAPI.Exception.ExceptionsBase;
using System.Text.Json;

namespace FrioAPI.Application.UseCases.ViaCep
{
    public class BuscaEnderecoViaCep : IBuscaEnderecoViaCep
    {
        private readonly HttpClient _httpClient;

        public BuscaEnderecoViaCep(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseViaCep?> BuscaCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            var endereco = JsonSerializer.Deserialize<ResponseViaCep>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (endereco?.Erro == true)
            {
                var errorMessages = new List<string>{ ResourceErrorMessages.CEP_NAO_ENCONTRADO };
                throw new ErrorOnValidationException(errorMessages);
            }
            return endereco;
        }
    }
}
