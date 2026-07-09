using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Administradora
{
    public class AtualizarAdministradoraDto
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; } = string.Empty;
        public string CnpjEmpresa { get; set; } = string.Empty;
        public string CnpjFundo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
