using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GerenciamentoAtivos.Domain.Models
{
    public class Administradora : BaseEntity
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public string CnpjEmpresa { get; set; } = string.Empty;
        public string CnpjFundo { get; set; } = string.Empty;
        public ICollection<Ativo> Ativos { get; set; } = [];

        [NotMapped]
        public string Nome
        {
            get => NomeFantasia;
            set => NomeFantasia = value;
        }
    }
}
