using GerenciamentoAtivos.Domain.Models;

namespace GerenciamentoAtivos.Domain.Services
{
    public interface ISegmentoService
    {
        Task<IEnumerable<Segmento>> Segmentos();
        Task<Segmento?> SegmentoById(Guid id);
        Task Create(Segmento data);
        Task Update(Segmento data);
        Task<Segmento?> DeleteById(Guid id);
    }
}
