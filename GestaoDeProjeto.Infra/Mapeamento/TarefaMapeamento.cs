using GestaoDeProjeto.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class TarefaMapeamento : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id_Empresa).IsRequired(true);
            builder.HasOne(t => t.Empresa).WithMany().HasForeignKey(t => t.Id_Empresa).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
            builder.Property(t => t.Id_Projeto).IsRequired(true);
            builder.HasOne(t => t.Projeto).WithMany().HasForeignKey(t => t.Id_Projeto).OnDelete(DeleteBehavior.Cascade).IsRequired(true);

            builder.Property(t => t.Descricao).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired(true);
            builder.Property(t => t.Objetivo).HasColumnType("VARCHAR").HasMaxLength(5000).IsRequired(true);
            builder.Property(t => t.Resultado).HasColumnType("VARCHAR").HasMaxLength(5000).IsRequired(true);
            builder.Property(t => t.Fase).IsRequired(true);
            builder.Property(t => t.Ordem).IsRequired(true);
            builder.Property(t => t.HorasEstimada).IsRequired(true);
            builder.Property(t => t.DataInicialEstimado).HasColumnType("DATETIME").IsRequired(true);
            builder.Property(t => t.DataFinalEstimado).HasColumnType("DATETIME").IsRequired(false);
            builder.Property(t => t.DataInicialRealizado).HasColumnType("DATETIME").IsRequired(true);
            builder.Property(t => t.DataFinalRealizado).HasColumnType("DATETIME").IsRequired(false);
            builder.Property(t => t.Sprint).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(false);
            builder.Property(t => t.Situacao).IsRequired(true);
  

        }
    }
}
