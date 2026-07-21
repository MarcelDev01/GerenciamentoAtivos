using GerenciamentoAtivos.Data.Context;
using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Data.Repositories
{
    public class AtivoRepository(AppDbContext context) : BaseRepository<Ativo>(context), IAtivoRepository
    {
        public async Task<IEnumerable<Ativo>> GetAllAtivosAsync()
        {
            return await _context.Ativos
                .AsNoTracking()
                .Include(a => a.Segmento)
                .Include(a => a.Administradora)
                .ToListAsync();
        }

        public async Task<Ativo?> GetByIdAtivoAsync(Guid id)
        {
            return await _context.Ativos
                .AsNoTracking()
                .Include(a => a.Segmento)
                .Include(a => a.Administradora)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
