using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using CL_Manager.ManagerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        public ClientesController(IClienteManager clienteManager)
        {
            _clienteManager = clienteManager;
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
            return Ok(await _clienteManager.GetClienteAsync());
        }

        /// <summary>
        /// Retorna um cliente consultado pelo Id
        /// </summary>
        /// <param name="id" exemple = "12">IdCliente</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(await _clienteManager.GetIdClienteAsync(id));
        }

        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        /// <param name="clienteView"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] ClienteView clienteView)
        {
            var clienteAdd = await _clienteManager.InsertClienteAsync(clienteView);

            return CreatedAtAction(nameof(GetId), new { id = clienteAdd.ClienteId }, clienteAdd);
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
