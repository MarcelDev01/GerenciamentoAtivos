using GerenciamentoAtivos.Service.DTO_s;

namespace GerenciamentoAtivos.Service.Interfaces
{
    public interface ILookupService
    {
        Task<List<LookupDto>> GetLookupAsync<T>() where T : class;
    }
}
