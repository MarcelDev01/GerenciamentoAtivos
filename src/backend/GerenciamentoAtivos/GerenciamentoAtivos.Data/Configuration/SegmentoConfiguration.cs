using GerenciamentoAtivos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Data.Configuration
{
    public class SegmentoConfiguration : BaseConfiguration<Segmento>
    {
        public void Configure(EntityTypeBuilder<Segmento> builder)
        {
            builder.ToTable("Segmentos"); // Garante o nome exato que você escolheu

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");
        }
    }
}
