using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class ProjetoRepositorio : RepositorioGenerico<Projeto>, IProjetoRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public ProjetoRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public async Task<List<Projeto>> BuscarTodosPorDescricaoAsync(string descricao, CancellationToken cancellationToken)
        {
            var resultado = new List<Projeto>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = await _contexto.Projeto.Include(a => a.Empresa).ToListAsync(cancellationToken);
            }
            else
            {
                resultado = await _contexto.Projeto.Where(b => b.Descricao.Contains(descricao)).ToListAsync(cancellationToken);
            }
            return resultado;
        }


        public async Task ExcluirAsync(int idProjeto, CancellationToken cancellationToken)
        {
            var projeto = await _contexto.Projeto.Where(a => a.Id == idProjeto).FirstOrDefaultAsync(cancellationToken);
            if (projeto != null)
            {
                _contexto.Projeto.Remove(projeto);
                await _contexto.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
