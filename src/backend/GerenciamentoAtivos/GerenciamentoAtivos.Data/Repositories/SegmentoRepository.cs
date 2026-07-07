using GerenciamentoAtivos.Data.Context;
using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Data.Repositories
{
    public class SegmentoRepository(AppDbContext context) : BaseRepository<Segmento>(context), ISegmentoRepository
    {
    }
}
