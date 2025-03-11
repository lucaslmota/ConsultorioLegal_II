using System.Text.Json.Serialization;

namespace CL_Core.Domain
{
    public class Telefone
    {
        public int ClienteId { get; set; }
        public string Numero { get; set; } = string.Empty;
        [JsonIgnore]
        public Cliente? Cliente{ get; set; }
    }
}