using GerenciamentoAtivos.Data.Repositories;
using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Domain.Services;
using GerenciamentoAtivos.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegmentoController(ISegmentoService segmentoService) : ControllerBase
    {
        private readonly ISegmentoService _segmentoService = segmentoService;

        [HttpGet("Segmentos/")]
        public async Task<IActionResult> Segmentos()
        {
            var result = await _segmentoService.Segmentos();
            return Ok(result);
        }

        [HttpGet("SegmentoByID/{id:guid}")]
        public async Task<IActionResult> SegmentoById(Guid id)
        {
            var result = await _segmentoService.SegmentoById(id);

            if (result == null)
                return NotFound(new { mensagem = "Segmento não encontrado." });

            return Ok(result);
        }

        [HttpPost("CriarSegmento/")]
        public async Task<IActionResult> Create([FromBody] Segmento data)
        {
            if (data == null)
                return BadRequest();

            await _segmentoService.Create(data);

            return Ok();
        }

        [HttpPatch("AtualizarSegmento/")]
        public async Task<IActionResult> Update([FromBody] Segmento data)
        {
            if (data == null)
                return BadRequest();

            await _segmentoService.Update(data);

            return Ok();
        }

        [HttpDelete("ExcluirSegmento/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _segmentoService.DeleteById(id);

            if (result == null)
                return NotFound(new { mensagem = "Erro ao excluir a segmento." });

            return Ok(result);
        }
    }
}
