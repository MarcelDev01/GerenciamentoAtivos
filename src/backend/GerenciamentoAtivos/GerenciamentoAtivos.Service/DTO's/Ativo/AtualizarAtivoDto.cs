using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Ativo
{
    public class AtualizarAtivoDto
    {
        public Guid Id { get; set; }
        public Guid SegmentoId { get; set; }
        public Guid AdministradoraId { get; set; }
        public string CodigoFII { get; set; } = string.Empty;
        public int QtdeCotas { get; set; }
        public decimal RendimentoUnitario { get; set; }
        public decimal PrecoCota { get; set; }
        public decimal ValorPatrimonial { get; set; }
        public bool Ativo { get; set; }
    }
}
