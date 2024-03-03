using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
using GestaoDeProjeto.Infra.Util;
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

        public List<Projeto> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Projeto>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.Projeto.Include(a => a.Empresa).ToList();
            }
            else
            {
                resultado = _contexto.Projeto.Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }


        public async Task ExcluirEmpresaEProjetos(int idProjeto)
        {
            //var aaa = _contexto.Projeto.ToList();
            //Projeto aassss = aaa.Where(a => a.Id == idProjeto).FirstOrDefault();
            //Projeto aaaa = aaa.Where(a => a.Id == 1).FirstOrDefault();
            var projeto = _contexto.Projeto.Where(a => a.Id == idProjeto).FirstOrDefault();
            // .Include(e => e.Empresa) // Certifique-se de incluir os projetos para excluir em cascata


            if (projeto != null)
            {
                _contexto.Projeto.Remove(projeto);
                //_contexto.Empresa.Remove(projeto.Empresa);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
