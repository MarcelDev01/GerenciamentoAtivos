using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Domain.Services;

namespace GerenciamentoAtivos.Service.Services
{
    public class SegmentoService(ISegmentoRepository segmentoRepository) : ISegmentoService
    {
        private readonly ISegmentoRepository _segmentoRepository = segmentoRepository;

        public async Task<IEnumerable<Segmento>> Segmentos()
        {
            var result = await _segmentoRepository.GetAllAsync();
            return result;
        }

        public async Task<Segmento?> SegmentoById(Guid id)
        {
            var result = await _segmentoRepository.GetByIdAsync(id);
            return result;
        }

        public async Task Create(Segmento data)
        {
            await _segmentoRepository.AddAsync(data);
            await _segmentoRepository.SaveChangesAsync();
        }

        public async Task Update(Segmento data)
        {
            _segmentoRepository.Update(data);
            await _segmentoRepository.SaveChangesAsync();
        }

        public async Task<Segmento?> DeleteById(Guid id)
        {
            var result = await _segmentoRepository.GetByIdAsync(id);

            if (result != null)
            {
                _segmentoRepository.Delete(result);
                await _segmentoRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}
