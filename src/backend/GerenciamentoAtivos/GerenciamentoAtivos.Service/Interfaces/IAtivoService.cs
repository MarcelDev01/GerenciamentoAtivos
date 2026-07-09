using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Ativo;

namespace GerenciamentoAtivos.Service.Interfaces
{
    public interface IAtivoService
    {
        Task<IEnumerable<AtivoDto>> Ativos();
        Task<AtivoDto> AtivoById(Guid id);
        Task<AtivoDto> Create(CriarAtivoDto data);
        Task<bool> Update(AtualizarAtivoDto data);
        Task<bool> DeleteById(Guid id);
    }
}
