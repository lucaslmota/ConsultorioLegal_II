﻿using Cl.Core.Shared.ModelViews;
using CL_Manager.ManagerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoManager _manager;
        private readonly ILogger _logger;

        public MedicosController(IMedicoManager manager, ILogger<MedicosController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os médicos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MedicoView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Teste medico");
            return Ok(await _manager.GetMedicosAsync());
        }

        /// <summary>
        /// Retorna um médico consultado via ID
        /// </summary>
        /// <param name="id" example="123">Id do médico</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _manager.GetMedicoAsync(id));
        }

        /// <summary>
        /// Insere um novo médico.
        /// </summary>
        /// <param name="medico"></param>
        [HttpPost]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NovoMedico medico)
        {
            _logger.LogInformation("Meidico: {@novoMedico}", medico);
            var medicoInserido = await _manager.InsertMedicoAsync(medico);
            return CreatedAtAction(nameof(Get), new { id = medicoInserido.Id }, medicoInserido);
        }

        /// <summary>
        /// Altera um médico
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(MedicoUpdateView medico)
        {
            var medicoAtualizado = await _manager.UpdateMedicoAsync(medico);
            if (medicoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(medicoAtualizado);
        }

        /// <summary>
        /// Exclui um médico.
        /// </summary>
        /// <param name="id" example="123">Id do médico</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _manager.DeleteMedicoAsync(id);
            return NoContent();
        }
    }
}
