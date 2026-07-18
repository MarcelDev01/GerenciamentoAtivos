using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAtivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController(ILookupService lookupService) : ControllerBase
    {
        private readonly ILookupService _lookupService = lookupService;

        [HttpGet("Segmentos")]
        public async Task<IActionResult> GetSegmentos()
        {
            var result = await _lookupService.GetLookupAsync<Segmento>();
            return Ok(result);
        }

        [HttpGet("Administradoras")]
        public async Task<IActionResult> GetAdministradoras()
        {
            var result = await _lookupService.GetLookupAsync<Administradora>();
            return Ok(result);
        }
    }
}
