using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
using GestaoDeProjeto.Infra.Util;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class ProjetoSquadRepositorio : RepositorioGenerico<ProjetoSquad>, IProjetoSquadRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public ProjetoSquadRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

    }
}
