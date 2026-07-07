using GerenciamentoAtivos.Domain.Models;

namespace GerenciamentoAtivos.Domain.Services
{
    public interface IAdministradoraService
    {
        Task<IEnumerable<Administradora>> Administradoras();
        Task<Administradora?> AdministradoraById(Guid id);
        Task Create(Administradora data);
        Task Update(Administradora data);
        Task<Administradora?> DeleteById(Guid id);
    }
}
