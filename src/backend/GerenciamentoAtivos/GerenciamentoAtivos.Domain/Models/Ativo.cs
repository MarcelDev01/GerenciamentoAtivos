using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GerenciamentoAtivos.Domain.Models
{
    public class Ativo : BaseEntity
    {
        //FK'S
        public Guid SegmentoId { get; set; }
        public Guid AdministradoraId { get; set; }

        public string CodigoFii { get; set; } = string.Empty;
        public int QuantidadeCotas { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal RendimentoUnitario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoCota { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPatrimonial { get; set; }

        public Segmento? Segmento { get; set; }
        public Administradora? Administradora { get; set; }

        [NotMapped]
        public decimal RendimentoTotal => QuantidadeCotas * RendimentoUnitario;

        [NotMapped]
        public decimal P_VP => ValorPatrimonial > 0 ? PrecoCota / ValorPatrimonial : 0;

        [NotMapped]
        public decimal TotalDesembolsado => QuantidadeCotas * PrecoCota;
    }
}
