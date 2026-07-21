using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Ativo;
using GerenciamentoAtivos.Service.Interfaces;

namespace GerenciamentoAtivos.Service.Services
{
    public class AtivoService(IAtivoRepository ativoRepository) : IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository = ativoRepository;

        public async Task<IEnumerable<AtivoDto>> Ativos()
        {
            IEnumerable<AtivoDto> lstAtivos = [];

            var ativos = await _ativoRepository.GetAllAtivosAsync();

            lstAtivos = ativos.Select(a => new AtivoDto
            {
                Id = a.Id,
                AdministradoraId = a.AdministradoraId,
                SegmentoId = a.SegmentoId,
                CodigoFII = a.CodigoFii,
                QtdeCotas = a.QuantidadeCotas,
                PrecoCota = a.PrecoCota,
                RendimentoUnitario = a.RendimentoUnitario,
                ValorPatrimonial = a.ValorPatrimonial,
                Ativo = a.Active,
                Created = a.Created,
                Updated = a.Updated,
                Segmento = a.Segmento.Nome,
                Administradora = a.Administradora.Nome
            }).ToList();

            return lstAtivos;
        }

        public async Task<AtivoDto> AtivoById(Guid id)
        {
            var ativo = await _ativoRepository.GetByIdAtivoAsync(id);

            AtivoDto ativoDto = new()
            {
                Id = ativo.Id,
                AdministradoraId = ativo.AdministradoraId,
                SegmentoId = ativo.SegmentoId,
                CodigoFII = ativo.CodigoFii,
                QtdeCotas = ativo.QuantidadeCotas,
                PrecoCota = ativo.PrecoCota,
                RendimentoUnitario = ativo.RendimentoUnitario,
                ValorPatrimonial = ativo.ValorPatrimonial,
                Ativo = ativo.Active,
                Created = ativo.Created,
                Updated = ativo.Updated,
                Segmento = ativo.Segmento.Nome,
                Administradora = ativo.Administradora.Nome
            };

            return ativoDto;
        }

        public async Task<AtivoDto> Create(CriarAtivoDto data)
        {
            Ativo ativo = new()
            {
                AdministradoraId = data.AdministradoraId,
                SegmentoId = data.SegmentoId,
                CodigoFii = data.CodigoFII.ToUpper(),
                QuantidadeCotas = data.QtdeCotas,
                RendimentoUnitario = data.RendimentoUnitario,
                PrecoCota = data.PrecoCota,
                ValorPatrimonial = data.ValorPatrimonial
            };

            await _ativoRepository.AddAsync(ativo);
            await _ativoRepository.SaveChangesAsync();

            return new AtivoDto
            {
                Id = ativo.Id,
                AdministradoraId = ativo.AdministradoraId,
                SegmentoId = ativo.SegmentoId,
                CodigoFII = ativo.CodigoFii,
                QtdeCotas = ativo.QuantidadeCotas,
                PrecoCota = ativo.PrecoCota,
                RendimentoUnitario = ativo.RendimentoUnitario,
                ValorPatrimonial = ativo.ValorPatrimonial,
                Ativo = ativo.Active,
                Created = ativo.Created,
                Updated = ativo.Updated
            };
        }

        public async Task<bool> Update(AtualizarAtivoDto data)
        {
            var ativo = await _ativoRepository.GetByIdAsync(data.Id);

            if (ativo == null) return false;

            ativo.SegmentoId = data.SegmentoId;
            ativo.AdministradoraId = data.AdministradoraId;
            ativo.CodigoFii = data.CodigoFII.ToUpper();
            ativo.QuantidadeCotas = data.QtdeCotas;
            ativo.RendimentoUnitario = data.RendimentoUnitario;
            ativo.PrecoCota = data.PrecoCota;
            ativo.ValorPatrimonial = data.ValorPatrimonial;

            _ativoRepository.Update(ativo);
            await _ativoRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var ativo = await _ativoRepository.GetByIdAsync(id);

            if (ativo == null) return false;
            
            _ativoRepository.Delete(ativo);
            await _ativoRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
