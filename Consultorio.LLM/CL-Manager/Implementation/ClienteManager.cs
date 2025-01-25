using CL_Core.Domain;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Implementation
{// basicamente essa classe é responsável por chamar o repositório e retornar os dados (Service)
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteManager(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetClienteAsync()
        {
            return await _clienteRepository.GetClienteAsync();
        }

        public async Task<Cliente?> GetIdClienteAsync(int id)
        {
            return await _clienteRepository.GetIdClienteAsync(id);
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente?> UpdadeteClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.UpdadeteClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
             await _clienteRepository.DeleteClienteAsync(id);
        }
    }
}
