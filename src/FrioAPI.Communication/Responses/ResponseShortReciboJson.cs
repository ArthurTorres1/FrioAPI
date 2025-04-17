namespace FrioAPI.Communication.Responses
{
    public class ResponseShortReciboJson
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string Equipamento { get; set; } = string.Empty;
        public string DescricaoServico { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
