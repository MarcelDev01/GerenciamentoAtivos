using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Domain.Interfaces
{
    public interface ILookupRepository
    {
        Task<List<T>> GetLookupDataAsync<T>() where T : class;
    }
}
