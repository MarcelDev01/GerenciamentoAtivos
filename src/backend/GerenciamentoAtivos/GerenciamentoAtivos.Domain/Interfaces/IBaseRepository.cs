using GerenciamentoAtivos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
