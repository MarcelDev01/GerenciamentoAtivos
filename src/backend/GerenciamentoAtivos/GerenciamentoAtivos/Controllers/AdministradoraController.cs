using GerenciamentoAtivos.Data.Repositories;
using GerenciamentoAtivos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradoraController(IAdministradoraRepository administradoraRepository) : ControllerBase
    {
        private readonly IAdministradoraRepository _administradoraRepository = administradoraRepository;

        [HttpGet("Administradoras/")]
        public async Task<IActionResult> GetAll()
        {
            var ativos = await _administradoraRepository.GetAllAsync();
            return Ok(ativos);
        }

        [HttpGet("AdministradoraByID/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ativo = await _administradoraRepository.GetByIdAsync(id);

            if (ativo == null)
                return NotFound(new { mensagem = "Administradora não encontrada." });

            return Ok(ativo);
        }

    }
}
