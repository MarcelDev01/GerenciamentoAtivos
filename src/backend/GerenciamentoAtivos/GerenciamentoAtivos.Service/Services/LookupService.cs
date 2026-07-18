using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Service.DTO_s;
using GerenciamentoAtivos.Service.Interfaces;

namespace GerenciamentoAtivos.Service.Services
{
    public class LookupService(ILookupRepository lookupRepository) : ILookupService
    {
        private readonly ILookupRepository _lookupRepository = lookupRepository;

        public async Task<List<LookupDto>> GetLookupAsync<T>() where T : class
        {
            var entidades = await _lookupRepository.GetLookupDataAsync<T>();

            // Transforma as entidades no DTO que o Front-end espera
            return entidades
                .Select(entidade => new LookupDto(
                    Id: (Guid)entidade.GetType().GetProperty("Id")!.GetValue(entidade)!,
                    Nome: entidade.GetType().GetProperty("Nome")!.GetValue(entidade)?.ToString() ?? ""
                ))
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
