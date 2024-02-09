using GestaoDeProjeto.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class SquadMapeamento : IEntityTypeConfiguration<Squad>
    {
        public void Configure(EntityTypeBuilder<Squad> builder)
        {

            builder.ToTable("Squad");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").HasColumnType("INT").UseIdentityColumn().IsRequired();
            builder.Property(s => s.Id_Empresa).HasColumnName("Id_Empresa").HasColumnType("INT").IsRequired();
            builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(s => s.ArrayImagem).HasColumnName("ArrayImagem").HasColumnType("VARBINARY(MAX)");
            builder.Property(s => s.UrlImagem).HasColumnName("UrlImagem").HasColumnType("VARCHAR(MAX)");
            builder.Property(s => s.Inativo).HasColumnName("Inativo").HasColumnType("BIT").HasDefaultValue(false).IsRequired();
            builder.HasOne(s => s.Empresa).WithMany(e => e.Squads).HasForeignKey(s => s.Id_Empresa).OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_Squad_Empresa");
            builder.HasIndex(s => new { s.Id_Empresa, s.Id }).IsUnique().HasName("IDX_Squad_UQ");


        }
    }
}
