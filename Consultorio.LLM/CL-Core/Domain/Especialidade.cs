using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Core.Domain
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Medico> Medicos { get; set; }
    }
}
