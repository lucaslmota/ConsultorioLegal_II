using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class ClienteView
    {
        public string ClienteNome { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public string Sexo { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
    }
}
