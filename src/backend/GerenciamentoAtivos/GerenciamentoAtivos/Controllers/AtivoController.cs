using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController(IAtivoRepository ativoRepository) : ControllerBase
    {
        private readonly IAtivoRepository _ativoRepository = ativoRepository;

        [HttpGet("Ativos/")]
        public async Task<IActionResult> GetAll()
        {
            var ativos = await _ativoRepository.GetAllAsync();
            return Ok(ativos);
        }

        [HttpGet("AtivoByID/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ativo = await _ativoRepository.GetByIdAsync(id);

            if (ativo == null)
                return NotFound(new { mensagem = "Ativo não encontrado." });

            return Ok(ativo);
        }

        [HttpPost("CriarAtivo/")]
        public async Task<IActionResult> Create([FromBody] Ativo novoAtivo)
        {
            if (novoAtivo == null)
                return BadRequest();

            // O EF Core vai salvar no banco e o C# vai calcular os campos com [NotMapped] na hora do retorno!
            await _ativoRepository.AddAsync(novoAtivo);
            await _ativoRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = novoAtivo.Id }, novoAtivo);
        }
    }
}
