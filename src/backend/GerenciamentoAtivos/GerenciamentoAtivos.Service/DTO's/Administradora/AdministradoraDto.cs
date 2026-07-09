using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Administradora
{
    public class AdministradoraDto
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; } = string.Empty;
        public string CnpjEmpresa { get; set; } = string.Empty;
        public string CnpjFundo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
