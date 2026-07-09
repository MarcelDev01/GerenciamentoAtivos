using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Segmento
{
    public class AtualizarSegmentoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
