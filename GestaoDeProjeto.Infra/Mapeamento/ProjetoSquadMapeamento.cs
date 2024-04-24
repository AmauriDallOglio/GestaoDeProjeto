using GestaoDeProjeto.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjeto.Infra.Mapeamento
{
    public class ProjetoSquadMapeamento : IEntityTypeConfiguration<ProjetoSquad>
    {
        public void Configure(EntityTypeBuilder<ProjetoSquad> builder)
        {
   
            builder.ToTable("ProjetoSquad");

 
            builder.HasKey(ps => ps.Id);

  
            builder.HasOne(ps => ps.Empresa).WithMany().HasForeignKey(ps => ps.Id_Empresa).IsRequired();

        
            builder.HasOne(ps => ps.Projeto).WithMany().HasForeignKey(ps => ps.Id_Projeto).IsRequired();

        
            builder.HasOne(ps => ps.Squad).WithMany().HasForeignKey(ps => ps.Id_Squad).IsRequired();

            // Propriedade Inativo
            builder.Property(ps => ps.Inativo).IsRequired().HasDefaultValue(false);
        }
    }
}
