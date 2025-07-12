using Cl.Core.Shared.ModelViews;
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
        Task<IEnumerable<ClienteView>> GetClienteAsync();
        Task<ClienteView?> GetIdClienteAsync(int id);
        Task<ClienteView> InsertClienteAsync(NewCliente cliente);
        Task<ClienteView?> UpdadeteClienteAsync(ClienteUpdateView cliente);
        Task<ClienteView> DeleteClienteAsync(int id);
    }
}
