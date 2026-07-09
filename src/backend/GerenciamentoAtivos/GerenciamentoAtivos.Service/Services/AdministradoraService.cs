using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Administradora;
using GerenciamentoAtivos.Service.DTO_s.Segmento;
using GerenciamentoAtivos.Service.Interfaces;

namespace GerenciamentoAtivos.Service.Services
{
    public class AdministradoraService(IAdministradoraRepository administradoraRepository) : IAdministradoraService
    {
        private readonly IAdministradoraRepository _administradoraRepository = administradoraRepository;

        public async Task<IEnumerable<AdministradoraDto>> Administradoras()
        {
            IEnumerable<AdministradoraDto> lstAdministradoras = [];

            var administradoras = await _administradoraRepository.GetAllAsync();

            lstAdministradoras = administradoras.Select(s => new AdministradoraDto
            {
                Id = s.Id,
                NomeFantasia = s.NomeFantasia,
                CnpjEmpresa = s.CnpjEmpresa,
                CnpjFundo = s.CnpjFundo,
                Ativo = s.Active,
                Created = s.Created,
                Updated = s.Updated
            }).ToList();

            return lstAdministradoras;
        }

        public async Task<AdministradoraDto> AdministradoraById(Guid id)
        {
            var administradora = await _administradoraRepository.GetByIdAsync(id);

            AdministradoraDto administradoraDto = new()
            {
                Id = administradora.Id,
                NomeFantasia = administradora.NomeFantasia,
                CnpjEmpresa = administradora.CnpjEmpresa,
                CnpjFundo = administradora.CnpjFundo,
                Ativo = administradora.Active,
                Created = administradora.Created,
                Updated = administradora.Updated
            };

            return administradoraDto;
        }

        public async Task<AdministradoraDto> Create(CriarAdministradoraDto data)
        {
            Administradora administradora = new()
            {
                NomeFantasia = data.NomeFantasia.ToUpper(),
                CnpjEmpresa = data.CnpjEmpresa.ToUpper(),
                CnpjFundo = data.CnpjFundo.ToUpper()
            };

            await _administradoraRepository.AddAsync(administradora);
            await _administradoraRepository.SaveChangesAsync();

            return new AdministradoraDto
            {
                Id = administradora.Id,
                NomeFantasia = administradora.NomeFantasia,
                CnpjEmpresa = administradora.CnpjEmpresa,
                CnpjFundo = administradora.CnpjFundo,
                Ativo = administradora.Active,
                Created = administradora.Created,
                Updated = administradora.Updated
            };
        }

        public async Task<bool> Update(AtualizarAdministradoraDto data)
        {
            var administradora = await _administradoraRepository.GetByIdAsync(data.Id);

            if(administradora == null) return false;

            administradora.NomeFantasia = data.NomeFantasia.ToUpper();
            administradora.CnpjEmpresa = data.CnpjEmpresa.ToUpper();
            administradora.CnpjFundo= data.CnpjFundo.ToUpper();
            administradora.Active = data.Ativo;

            _administradoraRepository.Update(administradora);
            await _administradoraRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var administradora = await _administradoraRepository.GetByIdAsync(id);

            if (administradora == null) return false;
            
            _administradoraRepository.Delete(administradora);
            await _administradoraRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
