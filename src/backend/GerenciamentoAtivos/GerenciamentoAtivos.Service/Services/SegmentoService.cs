using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Segmento;
using GerenciamentoAtivos.Service.Interfaces;

namespace GerenciamentoAtivos.Service.Services
{
    public class SegmentoService(ISegmentoRepository segmentoRepository) : ISegmentoService
    {
        private readonly ISegmentoRepository _segmentoRepository = segmentoRepository;

        public async Task<IEnumerable<SegmentoDto>> Segmentos()
        {
            IEnumerable<SegmentoDto> lstSegmentos = [];

            var result = await _segmentoRepository.GetAllAsync();

            lstSegmentos = result.Select(s => new SegmentoDto
            {
                Id = s.Id,
                Nome = s.Nome,
                Ativo = s.Active,
                Created = s.Created,
                Updated = s.Updated,
            }).ToList();

            return lstSegmentos;
        }

        public async Task<SegmentoDto> SegmentoById(Guid id)
        {
            var segmento = await _segmentoRepository.GetByIdAsync(id);

            SegmentoDto segmentoDto = new()
            {
                Id = segmento.Id,
                Nome = segmento.Nome,
                Ativo = segmento.Active,
                Created = segmento.Created,
                Updated = segmento.Updated,
            };

            return segmentoDto;
        }

        public async Task<SegmentoDto> Create(CriarSegmentoDto data)
        {
            //Validator

            Segmento segmento = new()
            {
                Nome = data.Nome.ToUpper()
            };

            await _segmentoRepository.AddAsync(segmento);
            await _segmentoRepository.SaveChangesAsync();

            return new SegmentoDto
            {
                Id = segmento.Id,
                Nome = segmento.Nome
            };
        }

        public async Task<bool> Update(AtualizarSegmentoDto data)
        {
            var segmento = await _segmentoRepository.GetByIdAsync(data.Id);

            if (segmento == null) return false;

            segmento.Nome = data.Nome.ToUpper();
            segmento.Active = data.Ativo;

            _segmentoRepository.Update(segmento);
            await _segmentoRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var result = await _segmentoRepository.GetByIdAsync(id);

            if (result == null) return false;

            _segmentoRepository.Delete(result);
            await _segmentoRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
