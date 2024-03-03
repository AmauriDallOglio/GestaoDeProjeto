using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestaoDeProjeto.Dominio.Entidade;
 

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class ProjetoMapeamento : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {


            builder.ToTable("Projeto");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").HasColumnType("INT").UseIdentityColumn().IsRequired();


            builder.Property(p => p.Id_Empresa).HasColumnName("Id_Empresa").HasColumnType("INT").IsRequired(true);
            builder.HasOne(p => p.Empresa).WithMany(e => e.ListaProjetos).HasForeignKey(p => p.Id_Empresa).OnDelete(DeleteBehavior.Restrict);


            builder.Property(p => p.NomeProjeto).HasColumnName("NomeProjeto").HasColumnType("varchar").HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasColumnType("varchar(MAX)").IsRequired(true);
            builder.Property(p => p.DataInicio).HasColumnName("DataInicio").HasColumnType("DATE").IsRequired();
            builder.Property(p => p.DataFim).HasColumnName("DataFim").HasColumnType("DATE");
            builder.Property(p => p.Situacao).HasColumnName("Situacao").HasColumnType("TINYINT").IsRequired();
 

        }
    }
} 



 