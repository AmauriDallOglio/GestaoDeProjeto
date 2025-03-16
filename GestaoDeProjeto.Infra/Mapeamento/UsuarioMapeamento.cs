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
            builder.Property(s => s.Id).HasColumnName("Id").HasColumnType("INT").UseIdentityColumn().IsRequired();
            //builder.Property(u => u.Id_Empresa).HasColumnName("Id_Empresa").HasColumnType("INT").IsRequired(true);
            //builder.HasOne(u => u.Empresa).WithMany(e => e.ListaUsuarios).HasForeignKey(u => u.Id_Empresa);
            builder.Property(u => u.Nome).HasMaxLength(300).HasColumnName("Nome").HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(u => u.Cargo).HasMaxLength(50).HasColumnName("Cargo").HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(u => u.Email).HasMaxLength(100).HasColumnName("Email").HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(u => u.Telefone).HasMaxLength(15).HasColumnName("Telefone").HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(u => u.Situacao).IsRequired(true);


        }
    }
}
