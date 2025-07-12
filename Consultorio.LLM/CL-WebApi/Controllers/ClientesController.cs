using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using CL_Manager.ManagerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace CL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        private readonly ILogger<ClientesController> _logger;
        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
        {
            _clienteManager = clienteManager;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteManager.GetClienteAsync();
            if (clientes.Any())
            {
                _logger.LogInformation("Teste");
                return Ok(clientes);
            }
            
            return NotFound();
        }

        /// <summary>
        /// Retorna um cliente consultado pelo Id
        /// </summary>
        /// <param name="id" exemple = "12">IdCliente</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var cliente = await _clienteManager.GetIdClienteAsync(id);
            if(cliente.ClienteId == 0)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        /// <param name="clienteView"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] NewCliente newCliente)
        {
            _logger.LogInformation("Objeto enviado: {@newCliente}", newCliente);

            ClienteView clienteInserido;
            using(Operation.Time("Tempo de add de cliente."))
            {
                _logger.LogInformation("Requisição de um novo cliente");
                clienteInserido = await _clienteManager.InsertClienteAsync(newCliente);
            }
            //var clienteAdd = await _clienteManager.InsertClienteAsync(clienteView);

            return CreatedAtAction(nameof(GetId), new { id = clienteInserido }, clienteInserido);
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="clienteUpdateView"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateClente([FromBody] ClienteUpdateView clienteUpdateView)
        {
            var clienteUpdate = await _clienteManager.UpdadeteClienteAsync(clienteUpdateView);
            if (clienteUpdate is null)
            {
                return NotFound();
            }
            return Ok(clienteUpdate);
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="id" example = "123" ></param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var clienteExcluido = await _clienteManager.DeleteClienteAsync(id);
            if (clienteExcluido is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
