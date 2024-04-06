using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public UsuarioRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }



    }
}
