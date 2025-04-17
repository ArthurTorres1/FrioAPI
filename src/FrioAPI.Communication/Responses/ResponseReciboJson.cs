namespace FrioAPI.Communication.Responses
{
    public class ResponseReciboJson
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string Equipamento { get; set; } = string.Empty;
        public string DescricaoServico { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
    }
}
