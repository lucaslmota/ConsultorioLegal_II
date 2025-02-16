using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class ClienteView
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        /// <example>Lucas Lima Mota</example>
        public string ClienteNome { get; set; } = string.Empty;

        /// <summary>
        /// Data de nascimento
        /// </summary>
        /// <example>1993-04-23</example>
        public DateTime DtNascimento { get; set; }
        /// <summary>
        /// Sexo
        /// </summary>
        /// <example>M</example>
        public string Sexo { get; set; } = string.Empty;
        /// <summary>
        /// Telefone
        /// </summary>
        /// <example>(88)9.9942-6105</example>
        public string Telefone { get; set; } = string.Empty;
        /// <summary>
        /// Cpf ou rg
        /// </summary>
        /// <example>057.693.133-07</example>
        public string Documento { get; set; } = string.Empty;
    }
}
