using GerenciamentoAtivos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoAtivos.Data.Configuration
{
    public class AtivoConfiguration : BaseConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("tbAtivos");

            builder.HasKey(a => a.Id);

            // Configuração dos campos de texto (varchar)
            builder.Property(a => a.CodigoFii)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar");

            // Configuração dos números decimais para evitar truncamento
            builder.Property(a => a.RendimentoUnitario)
                .HasColumnType("decimal(18,4)");

            builder.Property(a => a.PrecoCota)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.ValorPatrimonial)
                .HasColumnType("decimal(18,2)");

            // Configurando o Relacionamento: 1 Segmento tem Muitos Ativos
            builder.HasOne(a => a.Segmento)
                .WithMany(s => s.Ativos)
                .HasForeignKey(a => a.SegmentoId)
                .OnDelete(DeleteBehavior.Restrict); // Evita deletar um segmento com ativos vinculados

            // Configurando o Relacionamento: 1 Administradora tem Muitos Ativos
            builder.HasOne(a => a.Administradora)
                .WithMany(adm => adm.Ativos)
                .HasForeignKey(a => a.AdministradoraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
