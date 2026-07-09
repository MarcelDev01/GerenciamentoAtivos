using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Segmento;

namespace GerenciamentoAtivos.Service.Interfaces
{
    public interface ISegmentoService
    {
        Task<IEnumerable<SegmentoDto>> Segmentos();
        Task<SegmentoDto> SegmentoById(Guid id);
        Task<SegmentoDto> Create(CriarSegmentoDto data);
        Task<bool> Update(AtualizarSegmentoDto data);
        Task<bool> DeleteById(Guid id);
    }
}
