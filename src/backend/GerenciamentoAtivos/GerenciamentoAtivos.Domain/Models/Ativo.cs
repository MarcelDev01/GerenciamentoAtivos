using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Domain.Models
{
    public class Ativo : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
    }
}
