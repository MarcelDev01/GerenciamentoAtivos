using GerenciamentoAtivos.Domain.Models;
using GerenciamentoAtivos.Service.DTO_s.Administradora;

namespace GerenciamentoAtivos.Service.Interfaces
{
    public interface IAdministradoraService
    {
        Task<IEnumerable<AdministradoraDto>> Administradoras();
        Task<AdministradoraDto> AdministradoraById(Guid id);
        Task<AdministradoraDto> Create(CriarAdministradoraDto data);
        Task<bool> Update(AtualizarAdministradoraDto data);
        Task<bool> DeleteById(Guid id);
    }
}
