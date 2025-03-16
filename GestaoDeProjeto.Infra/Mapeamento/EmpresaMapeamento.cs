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
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id").HasColumnType("INT").UseIdentityColumn().IsRequired();
            builder.Property(e => e.RazaoSocial).HasColumnName("RazaoSocial").HasColumnType("VARCHAR").HasMaxLength(300).IsRequired();
            builder.Property(e => e.NomeFantasia).HasColumnName("NomeFantasia").HasColumnType("VARCHAR").HasMaxLength(300).IsRequired();
            builder.Property(e => e.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.Cnpj).HasColumnName("Cnpj").HasColumnType("VARCHAR").HasMaxLength(14).IsRequired();
            builder.Property(e => e.PessoaContato).HasColumnName("PessoaContato").HasColumnType("VARCHAR").HasMaxLength(300);
            builder.Property(e => e.Email).HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(300);
            builder.Property(e => e.Telefone).HasColumnName("Telefone").HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Property(e => e.Endereco).HasColumnName("Endereco").HasColumnType("VARCHAR").HasMaxLength(300);
            builder.Property(e => e.Numero).HasColumnName("Numero").HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(e => e.Complemento).HasColumnName("Complemento").HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(e => e.Cep).HasColumnName("Cep").HasColumnType("VARCHAR").HasMaxLength(8);
            builder.Property(e => e.Cidade).HasColumnName("Cidade").HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(e => e.Estado).HasColumnName("Estado").HasColumnType("CHAR").HasMaxLength(2);
            builder.Property(e => e.Inativo).HasColumnName("Inativo").HasColumnType("BIT").HasDefaultValue(false).IsRequired();

            //// Relacionamento com a tabela Projeto
            //builder.HasMany(e => e.ListaProjetos).WithOne(p => p.Empresa).HasForeignKey(p => p.Id_Empresa).OnDelete(DeleteBehavior.Restrict);
            //builder.HasMany(e => e.ListaSquads).WithOne(p => p.Empresa).HasForeignKey(p => p.Id_Empresa).OnDelete(DeleteBehavior.Restrict);
            //builder.HasMany(e => e.ListaUsuarios).WithOne(p => p.Empresa).HasForeignKey(p => p.Id_Empresa).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

 