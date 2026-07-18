using GerenciamentoAtivos.Data.Context;
using GerenciamentoAtivos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace GerenciamentoAtivos.Data.Repositories
{
    public class LookupRepository(AppDbContext context) : ILookupRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<T>> GetLookupDataAsync<T>() where T : class
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
