using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Segmento
{
    public class SegmentoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
