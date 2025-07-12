using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class NewEndereco
    {
        /// <example>63700-112</example>
        public string CEP { get; set; } = string.Empty;

        public EEstadoView Estado { get; set; }
        /// <example>Crateús</example>
        public string Cidade { get; set; } = string.Empty;
        /// <example>Rua Dr João Tomé</example>
        public string Logradouro { get; set; } = string.Empty;
        /// <example>726</example>
        public string Numero { get; set; } = string.Empty;
        /// <example>Príximo ao Céu azul</example>
        public string Complemento { get; set; } = string.Empty;
    }
}
