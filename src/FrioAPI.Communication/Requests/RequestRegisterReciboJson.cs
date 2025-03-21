﻿namespace FrioAPI.Communication.Requests
{
    public class RequestRegisterReciboJson
    {
        public string Nome {  get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty; 
        public string DescricaoServico {  get; set; } = string.Empty;
        public DateTime Data {  get; set; }
        public decimal Total {  get; set; }

    }
}
