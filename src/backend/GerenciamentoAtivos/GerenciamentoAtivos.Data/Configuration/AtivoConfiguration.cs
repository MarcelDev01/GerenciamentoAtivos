using GerenciamentoAtivos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoAtivos.Data.Configuration
{
    public class AtivoConfiguration : BaseConfiguration<Ativo>
    {
        public override void Configure(EntityTypeBuilder<Ativo> builder)
        {
            // Primeiro chama a base para configurar ID, CreatedAt e IsActive
            base.Configure(builder);

            // Depois as configurações específicas
            builder.ToTable("Ativos");

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
