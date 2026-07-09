using GerenciamentoAtivos.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoAtivos.Service.DTO_s.Segmento;

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
        public async Task<IActionResult> Create([FromBody] CriarSegmentoDto data)
        {
            if (data == null)
                return BadRequest();

            var segmento = await _segmentoService.Create(data);

            return Ok(segmento);
        }

        [HttpPatch("AtualizarSegmento/")]
        public async Task<IActionResult> Update([FromBody] AtualizarSegmentoDto data)
        {
            if (data == null)
                return BadRequest();

            var result = await _segmentoService.Update(data);

            if (!result)
                return NotFound(new { mensagem = "Segmento não encontrado para atualização." });

            return Ok();
        }

        [HttpDelete("ExcluirSegmento/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _segmentoService.DeleteById(id);

            if (!result)
                return NotFound(new { mensagem = "Segmento não encontrado para exclusão." });

            return Ok();
        }
    }
}
