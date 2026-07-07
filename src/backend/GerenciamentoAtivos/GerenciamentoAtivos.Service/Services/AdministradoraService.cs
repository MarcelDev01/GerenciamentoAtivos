using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Domain.Services;

namespace GerenciamentoAtivos.Service.Services
{
    public class AdministradoraService(IAdministradoraRepository administradoraRepository) : IAdministradoraService
    {
        private readonly IAdministradoraRepository _administradoraRepository = administradoraRepository;

        public async Task<IEnumerable<Administradora>> Administradoras()
        {
            var result = await _administradoraRepository.GetAllAsync();
            return result;
        }

        public async Task<Administradora?> AdministradoraById(Guid id)
        {
            var result = await _administradoraRepository.GetByIdAsync(id);
            return result;
        }

        public async Task Create(Administradora data)
        {
            await _administradoraRepository.AddAsync(data);
            await _administradoraRepository.SaveChangesAsync();
        }

        public async Task Update(Administradora data)
        {
            _administradoraRepository.Update(data);
            await _administradoraRepository.SaveChangesAsync();
        }

        public async Task<Administradora?> DeleteById(Guid id)
        {
            var result = await _administradoraRepository.GetByIdAsync(id);

            if (result != null)
            {
                _administradoraRepository.Delete(result);
                await _administradoraRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}
