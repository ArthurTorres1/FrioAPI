namespace FrioAPI.Communication.Requests
{
    public class RequestRegisterReciboJson
    {
        public string NomeCliente {  get; set; } = string.Empty;
        public string Equipamento { get; set; } = string.Empty; 
        //public string Endereco { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty; 
        //public string CEP { get; set; } = string.Empty -- melhoria quando for criar o front
        public string DescricaoServico {  get; set; } = string.Empty;
        public DateTime Data {  get; set; }
        public decimal Total {  get; set; }

    }
}
