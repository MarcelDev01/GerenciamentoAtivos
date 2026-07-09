using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Service.DTO_s.Administradora
{
    public class CriarAdministradoraDto
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public string CnpjEmpresa { get; set; } = string.Empty;
        public string CnpjFundo { get; set; } = string.Empty;
    }
}
