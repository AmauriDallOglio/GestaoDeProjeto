using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class TarefaRepositorio : RepositorioGenerico<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {

        }


    }
}
