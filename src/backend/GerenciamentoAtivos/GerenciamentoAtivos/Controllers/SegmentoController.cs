using GerenciamentoAtivos.Data.Repositories;
using GerenciamentoAtivos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegmentoController(ISegmentoRepository segmentoRepository) : ControllerBase
    {
        private readonly ISegmentoRepository _segmentoRepository = segmentoRepository;

        [HttpGet("Segmentos/")]
        public async Task<IActionResult> GetAll()
        {
            var ativos = await _segmentoRepository.GetAllAsync();
            return Ok(ativos);
        }

        [HttpGet("SegmentoByID/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ativo = await _segmentoRepository.GetByIdAsync(id);

            if (ativo == null)
                return NotFound(new { mensagem = "Segmento não encontrado." });

            return Ok(ativo);
        }
    }
}
