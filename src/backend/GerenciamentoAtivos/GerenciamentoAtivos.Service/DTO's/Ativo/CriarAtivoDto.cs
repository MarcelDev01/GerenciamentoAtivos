using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Ativo
{
    public class CriarAtivoDto
    {
        public Guid SegmentoId { get; set; }
        public Guid AdministradoraId { get; set; }
        public string CodigoFII { get; set; } = string.Empty;
        public int QtdeCotas { get; set; }
        public decimal RendimentoUnitario { get; set; }
        public decimal PrecoCota { get; set; }
        public decimal ValorPatrimonial { get; set; }
    }
}
