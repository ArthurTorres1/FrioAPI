namespace FrioAPI.Domain.Entities
{
    public class Recibo
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string Equipamento { get; set; } = string.Empty;
        public string DescricaoServico { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
    }
}
