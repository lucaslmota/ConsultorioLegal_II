using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Core.Domain
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public string Sexo { get; set; } = string.Empty;
        public ICollection<Telefone>? Telefones { get; set; }
        public string Documento { get; set; } = string.Empty;
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        //Relação 1:1
        public Endereco? Endereco { get; set; }
    }
}
