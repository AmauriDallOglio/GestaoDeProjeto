using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Infra.Mapeamento.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Contexto
{

    public class GenericoContexto : DbContext
    {
        private readonly GestaoDeProjetoContexto _gestaoDeProjetoContexto;


        public GenericoContexto(DbContextOptions options) : base(options)
        {
         
        }

        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguracaoMapeamento.Injetar(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

    }

}
