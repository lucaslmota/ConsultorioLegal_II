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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteManager.GetClienteAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(await _clienteManager.GetIdClienteAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] Cliente cliente)
        {
            var clienteAdd = await _clienteManager.InsertClienteAsync(cliente);

            return CreatedAtAction(nameof(GetId), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClente([FromBody] Cliente cliente)
        {
            var clienteUpdate = await _clienteManager.UpdadeteClienteAsync(cliente);
            if (clienteUpdate is null)
            {
                return NotFound();
            }
            return Ok(clienteUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
