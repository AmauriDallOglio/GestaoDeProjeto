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

        public async Task<List<Projeto>> BuscarTodosPorDescricaoAsync(string descricao)
        {
            var resultado = new List<Projeto>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = await _contexto.Projeto.Include(a => a.Empresa).ToListAsync();
            }
            else
            {
                resultado = await _contexto.Projeto.Where(b => b.Descricao.Contains(descricao)).ToListAsync();
            }
            return resultado;
        }


        public async Task ExcluirEmpresaEProjetosAsync(int idProjeto)
        {
            //var aaa = _contexto.Projeto.ToList();
            //Projeto aassss = aaa.Where(a => a.Id == idProjeto).FirstOrDefault();
            //Projeto aaaa = aaa.Where(a => a.Id == 1).FirstOrDefault();
            var projeto = await _contexto.Projeto.Where(a => a.Id == idProjeto).FirstOrDefaultAsync();
            // .Include(e => e.Empresa) // Certifique-se de incluir os projetos para excluir em cascata


            if (projeto != null)
            {
                _contexto.Projeto.Remove(projeto);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
