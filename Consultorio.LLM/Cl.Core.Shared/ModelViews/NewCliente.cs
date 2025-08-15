using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo cliente.
    /// </summary>
    public class NewCliente
    {
        // <summary>
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
        public ESexoView Sexo { get; set; }
        /// <summary>
        /// Cpf ou rg
        /// </summary>
        /// <example>057.693.133-07</example>
        public string Documento { get; set; } = string.Empty;

        public NewEndereco Endereco { get; set; }


        public ICollection<NewTelefone>? Telefones { get; set; }
    }
}
