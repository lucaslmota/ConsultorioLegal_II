namespace CL_Core.Domain
{
    public class Endereco
    {
        public int ClienteId { get; set; }
        public string CEP { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;

        //Relação 1:1
        public Cliente Cliente { get; set; } 
    }
}