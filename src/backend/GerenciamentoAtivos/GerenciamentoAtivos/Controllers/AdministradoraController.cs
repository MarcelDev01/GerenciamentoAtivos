using GerenciamentoAtivos.Data.Repositories;
using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Domain.Services;
using GerenciamentoAtivos.Service.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradoraController(IAdministradoraService administradoraService) : ControllerBase
    {
        private readonly IAdministradoraService _administradoraService = administradoraService;

        [HttpGet("Administradoras/")]
        public async Task<IActionResult> Administradoras()
        {
            var result = await _administradoraService.Administradoras();
            return Ok(result);
        }

        [HttpGet("AdministradoraByID/{id:guid}")]
        public async Task<IActionResult> AdministradoraById(Guid id)
        {
            var result = await _administradoraService.AdministradoraById(id);

            if (result == null)
                return NotFound(new { mensagem = "Administradora não encontrada." });

            return Ok(result);
        }

        [HttpPost("CriarAdministradora/")]
        public async Task<IActionResult> Create([FromBody] Administradora data)
        {
            if (data == null)
                return BadRequest();

            await _administradoraService.Create(data);

            return Ok();
        }

        [HttpPatch("AtualizarAdministradora/")]
        public async Task<IActionResult> Update([FromBody] Administradora data)
        {
            if (data == null)
                return BadRequest();

            await _administradoraService.Update(data);

            return Ok();
        }

        [HttpDelete("ExcluirAdministradora/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _administradoraService.DeleteById(id);

            if (result == null)
                return NotFound(new { mensagem = "Erro ao excluir a administradora." });

            return Ok(result);
        }
    }
}
