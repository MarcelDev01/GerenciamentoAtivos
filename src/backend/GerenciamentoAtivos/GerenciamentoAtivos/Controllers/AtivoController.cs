using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Ativo;
using GerenciamentoAtivos.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> Create([FromBody] CriarAtivoDto data)
        {
            if (data == null)
                return BadRequest();

            var ativo = await _ativoService.Create(data);

            return Ok(ativo);
        }

        [HttpPatch("AtualizarAtivo/")]
        public async Task<IActionResult> Update([FromBody] AtualizarAtivoDto data)
        {
            if (data == null)
                return BadRequest();

            var result = await _ativoService.Update(data);

            if (!result)
                return NotFound(new { mensagem = "Segmento não encontrado para atualização." });

            return Ok();
        }

        [HttpDelete("ExcluirAtivo/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _ativoService.DeleteById(id);

            if (!result)
                return NotFound(new { mensagem = "Ativo não encontrado para exclusão." });

            return Ok(result);
        }
    }
}
