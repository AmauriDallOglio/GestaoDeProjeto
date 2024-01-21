using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Contexto
{
    public class GestaoDeProjetoContexto : GenericoContexto
    {
        public GestaoDeProjetoContexto(DbContextOptions<GestaoDeProjetoContexto> options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}