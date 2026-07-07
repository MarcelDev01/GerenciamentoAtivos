using GerenciamentoAtivos.Domain.Models;

namespace GerenciamentoAtivos.Domain.Services
{
    public interface IAtivoService
    {
        Task<IEnumerable<Ativo>> Ativos();
        Task<Ativo?> AtivoById(Guid id);
        Task Create(Ativo data);
        Task Update(Ativo data);
        Task<Ativo?> DeleteById(Guid id);
    }
}
