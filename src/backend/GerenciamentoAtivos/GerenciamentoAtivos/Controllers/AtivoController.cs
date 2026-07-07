using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController(IAtivoService ativoService) : ControllerBase
    {
        private readonly IAtivoService _ativoService = ativoService;

        [HttpGet("Ativos/")]
        public async Task<IActionResult> Ativos()
        {
            var result = await _ativoService.Ativos();
            return Ok(result);
        }

        [HttpGet("AtivoByID/{id:guid}")]
        public async Task<IActionResult> AtivoById(Guid id)
        {
            var result = await _ativoService.AtivoById(id);

            if (result == null)
                return NotFound(new { mensagem = "Ativo não encontrado." });

            return Ok(result);
        }

        [HttpPost("CriarAtivo/")]
        public async Task<IActionResult> Create([FromBody] Ativo data)
        {
            if (data == null)
                return BadRequest();

            await _ativoService.Create(data);

            return Ok();
        }

        [HttpPatch("AtualizarAtivo/")]
        public async Task<IActionResult> Update([FromBody] Ativo data)
        {
            if (data == null)
                return BadRequest();

            await _ativoService.Update(data);

            return Ok();
        }

        [HttpDelete("ExcluirAtivo/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _ativoService.DeleteById(id);

            if (result == null)
                return NotFound(new { mensagem = "Erro ao excluir o ativo." });

            return Ok(result);
        }
    }
}
