using GestaoDeProjeto.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class EmpresaMapeamento : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
 
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasColumnType("varchar(MAX)").IsRequired(true);
            builder.Property(p => p.Status).HasColumnName("Status").HasColumnType("smallint").IsRequired();
        }
    }
}

