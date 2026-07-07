using GerenciamentoAtivos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoAtivos.Data.Configuration
{
    public class AdministradoraConfiguration : BaseConfiguration<Administradora>
    {
        public void Configure(EntityTypeBuilder<Administradora> builder)
        {
            builder.ToTable("Administradora");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.NomeFantasia)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.Property(a => a.CnpjEmpresa)
                .HasMaxLength(18)
                .HasColumnType("varchar");

            builder.Property(a => a.CnpjFundo)
                .HasMaxLength(18)
                .HasColumnType("varchar");
        }
    }
}
