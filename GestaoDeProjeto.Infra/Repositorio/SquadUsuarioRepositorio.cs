using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class SquadUsuarioRepositorio : RepositorioGenerico<SquadUsuario>, ISquadUsuarioRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public SquadUsuarioRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

    }
}
