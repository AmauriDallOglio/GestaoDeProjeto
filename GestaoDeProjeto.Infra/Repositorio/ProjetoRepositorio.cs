using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class ProjetoRepositorio : RepositorioGenerico<Projeto>, IProjetoRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public ProjetoRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public List<Projeto> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Projeto>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.Projeto.ToList();
            }
            else
            {
                resultado = _contexto.Projeto.Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }
    }
}
