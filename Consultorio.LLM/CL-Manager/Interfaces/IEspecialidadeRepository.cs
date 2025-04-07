using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Interfaces
{
    public interface IEspecialidadeRepository
    {
        bool ExisteAsync(int id);
    }
}
