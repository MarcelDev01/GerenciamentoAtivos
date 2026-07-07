using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Domain.Services;

namespace GerenciamentoAtivos.Service.Services
{
    public class AtivoService(IAtivoRepository ativoRepository) : IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository = ativoRepository;

        public async Task<IEnumerable<Ativo>> Ativos()
        {
            var result = await _ativoRepository.GetAllAsync();
            return result;
        }

        public async Task<Ativo?> AtivoById(Guid id)
        {
            var result = await _ativoRepository.GetByIdAsync(id);
            return result;
        }

        public async Task Create(Ativo data)
        {
            await _ativoRepository.AddAsync(data);
            await _ativoRepository.SaveChangesAsync();
        }

        public async Task Update(Ativo data)
        {
            _ativoRepository.Update(data);
            await _ativoRepository.SaveChangesAsync();
        }

        public async Task<Ativo?> DeleteById(Guid id)
        {
            var result = await _ativoRepository.GetByIdAsync(id);

            if (result != null)
            {
                _ativoRepository.Delete(result);
                await _ativoRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}
