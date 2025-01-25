using CL_Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.ManagerInterface
{
    public interface IClienteManager
    {
        Task<IEnumerable<Cliente>> GetClienteAsync();
        Task<Cliente?> GetIdClienteAsync(int id);
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente?> UpdadeteClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}
