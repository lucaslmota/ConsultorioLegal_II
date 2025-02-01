using AutoMapper;
using Cl.Core.Shared.ModelViews;
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
        private readonly IMapper _mapper;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetClienteAsync()
        {
            return await _clienteRepository.GetClienteAsync();
        }

        public async Task<Cliente?> GetIdClienteAsync(int id)
        {
            return await _clienteRepository.GetIdClienteAsync(id);
        }

        public async Task<Cliente> InsertClienteAsync(ClienteView clienteView)
        {
            var Cliente = _mapper.Map<Cliente>(clienteView);
            return await _clienteRepository.InsertClienteAsync(Cliente);
        }

        public async Task<Cliente?> UpdadeteClienteAsync(ClienteUpdateView clienteUpdateView)
        {
            var updateCliente = _mapper.Map<Cliente>(clienteUpdateView);
            return await _clienteRepository.UpdadeteClienteAsync(updateCliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
             await _clienteRepository.DeleteClienteAsync(id);
        }
    }
}
