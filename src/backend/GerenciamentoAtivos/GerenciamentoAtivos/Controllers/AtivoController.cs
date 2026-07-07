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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ativos = await _ativoRepository.GetAllAsync();
            return Ok(ativos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ativo = await _ativoRepository.GetByIdAsync(id);

            if (ativo == null)
                return NotFound(new { mensagem = "Ativo não encontrado." });

            return Ok(ativo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ativo novoAtivo)
        {
            if (novoAtivo == null)
                return BadRequest();

            // Lembra que NÃO setamos CreatedAt nem IsActive na mão? 
            // O nosso AppDbContext vai fazer isso sozinho no SaveChanges!
            await _ativoRepository.AddAsync(novoAtivo);
            await _ativoRepository.SaveChangesAsync();

            // Retorna o status 201 (Created) e mostra onde o recurso foi criado
            return CreatedAtAction(nameof(GetById), new { id = novoAtivo.Id }, novoAtivo);
        }
    }
}
