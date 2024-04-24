using GestaoDeProjeto.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class SquadUsuarioMapeamento : IEntityTypeConfiguration<SquadUsuario>
    {
        public void Configure(EntityTypeBuilder<SquadUsuario> builder)
        {

            builder.ToTable("SquadUsuario");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").HasColumnType("INT").UseIdentityColumn().IsRequired(true);


            builder.Property(s => s.Id_Empresa).HasColumnName("Id_Empresa").HasColumnType("INT").IsRequired(true);
            builder.HasOne(u => u.Empresa).WithMany().HasForeignKey(u => u.Id_Empresa).OnDelete(DeleteBehavior.Restrict);


            builder.Property(s => s.Id_Squad).HasColumnName("Id_Squad").HasColumnType("INT").IsRequired(true);
            builder.HasOne(u => u.Squad).WithMany().HasForeignKey(u => u.Id_Squad).OnDelete(DeleteBehavior.Restrict);


            builder.Property(s => s.Id_Usuario).HasColumnName("Id_Usuario").HasColumnType("INT").IsRequired(true);
            builder.HasOne(u => u.Usuario).WithMany().HasForeignKey(u => u.Id_Usuario).OnDelete(DeleteBehavior.Restrict);

            builder.Property(ps => ps.Inativo).IsRequired().HasDefaultValue(false);
        }
    }
}