using GerenciamentoAtivos.Service.DTO_s.Administradora;
using GerenciamentoAtivos.Service.Interfaces;
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
        public async Task<IActionResult> Create([FromBody] CriarAdministradoraDto data)
        {
            if (data == null)
                return BadRequest();

            var administradora = await _administradoraService.Create(data);

            return Ok(administradora);
        }

        [HttpPatch("AtualizarAdministradora/")]
        public async Task<IActionResult> Update([FromBody] AtualizarAdministradoraDto data)
        {
            if (data == null)
                return BadRequest();

            var result = await _administradoraService.Update(data);

            if (!result)
                return NotFound(new { mensagem = "Administradora não encontrada para atualização." });

            return Ok();
        }

        [HttpDelete("ExcluirAdministradora/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _administradoraService.DeleteById(id);

            if (!result)
                return NotFound(new { mensagem = "Administradora não encontrada para exclusão." });

            return Ok(result);
        }
    }
}
