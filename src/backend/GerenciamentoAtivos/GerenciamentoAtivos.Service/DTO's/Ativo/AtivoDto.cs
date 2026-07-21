using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Ativo
{
    public class AtivoDto
    {
        public Guid Id { get; set; }
        public Guid SegmentoId { get; set; }
        public string Segmento { get; set; } = string.Empty;
        public Guid AdministradoraId { get; set; }
        public string Administradora { get; set; } = string.Empty;
        public string CodigoFII { get; set; } = string.Empty;
        public int QtdeCotas { get; set; }
        public decimal RendimentoUnitario { get; set; }
        public decimal PrecoCota { get; set; }
        public decimal ValorPatrimonial { get; set; }
        public bool Ativo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
