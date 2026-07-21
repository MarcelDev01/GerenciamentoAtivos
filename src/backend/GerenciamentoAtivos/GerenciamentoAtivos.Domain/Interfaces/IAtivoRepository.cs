using GerenciamentoAtivos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Domain.Interfaces
{
    public interface IAtivoRepository : IBaseRepository<Ativo>
    {
        Task<IEnumerable<Ativo>> GetAllAtivosAsync();
        Task<Ativo?> GetByIdAtivoAsync(Guid id);
    }
}
