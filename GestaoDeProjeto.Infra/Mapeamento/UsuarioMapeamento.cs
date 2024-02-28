using GestaoDeProjeto.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id_Empresa).IsRequired();
            builder.Property(u => u.Nome).HasMaxLength(100);
            builder.Property(u => u.Cargo).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Telefone).HasMaxLength(15);
            builder.Property(u => u.Situacao).IsRequired();
            builder.HasOne(u => u.Empresa).WithMany().HasForeignKey(u => u.Id_Empresa);

        }
    }
}
