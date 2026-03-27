using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Domain.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
    }
}
