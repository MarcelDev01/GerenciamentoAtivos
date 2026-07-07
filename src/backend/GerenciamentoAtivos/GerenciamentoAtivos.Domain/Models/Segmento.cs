using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Domain.Models
{
    public class Segmento : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public ICollection<Ativo> Ativos { get; set; } = [];
    }
}
