using AutoMapper;
using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ClienteManager> _logger;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper, ILogger<ClienteManager> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ClienteView>> GetClienteAsync()
        {
            var clientes = await _clienteRepository.GetClienteAsync();
            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(clientes);
        }

        public async Task<ClienteView?> GetIdClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetIdClienteAsync(id);
            return _mapper.Map<ClienteView>(cliente);
        }

        public async Task<ClienteView> InsertClienteAsync(NewCliente clienteView)
        {
            var Cliente = _mapper.Map<Cliente>(clienteView);
            Cliente = await _clienteRepository.InsertClienteAsync(Cliente);
            return _mapper.Map<ClienteView>(Cliente);
        }

        public async Task<ClienteView> UpdadeteClienteAsync(ClienteUpdateView clienteUpdateView)
        {
            var upCliente = _mapper.Map<Cliente>(clienteUpdateView);
            upCliente = await _clienteRepository.UpdadeteClienteAsync(upCliente);
            return _mapper.Map<ClienteView>(upCliente);
        }

        public async Task<ClienteView> DeleteClienteAsync(int id)
        {
            var cliente = await _clienteRepository.DeleteClienteAsync(id);
            return _mapper.Map<ClienteView>(cliente);
        }
    }
}
