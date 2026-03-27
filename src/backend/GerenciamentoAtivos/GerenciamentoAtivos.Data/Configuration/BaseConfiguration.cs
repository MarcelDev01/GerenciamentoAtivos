using GerenciamentoAtivos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoAtivos.Data.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Active)
                .HasDefaultValue(true);

            // O UpdatedAt fica opcional por padrão
        }
    }
}
