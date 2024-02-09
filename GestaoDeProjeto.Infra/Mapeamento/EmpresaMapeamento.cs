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
            builder.Property(e => e.RazaoSocial).HasColumnName("RazaoSocial").HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(e => e.NomeFantasia).HasColumnName("NomeFantasia").HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(e => e.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.Cnpj).HasColumnName("Cnpj").HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(e => e.PessoaContato).HasColumnName("PessoaContato").HasColumnType("VARCHAR(300)");
            builder.Property(e => e.Email).HasColumnName("Email").HasColumnType("VARCHAR(300)");
            builder.Property(e => e.Telefone).HasColumnName("Telefone").HasColumnType("VARCHAR(50)");
            builder.Property(e => e.Endereco).HasColumnName("Endereco").HasColumnType("VARCHAR(300)");
            builder.Property(e => e.Numero).HasColumnName("Numero").HasColumnType("VARCHAR(20)");
            builder.Property(e => e.Complemento).HasColumnName("Complemento").HasColumnType("VARCHAR(100)");
            builder.Property(e => e.Cep).HasColumnName("Cep").HasColumnType("VARCHAR(8)");
            builder.Property(e => e.Cidade).HasColumnName("Cidade").HasColumnType("VARCHAR(100)");
            builder.Property(e => e.Estado).HasColumnName("Estado").HasColumnType("CHAR(2)");
            builder.Property(e => e.Inativo).HasColumnName("Inativo").HasColumnType("BIT").HasDefaultValue(false).IsRequired();

        }
    }
}

