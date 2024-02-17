using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
using GestaoDeProjeto.Infra.Util;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class EmpresaRepositorio : RepositorioGenerico<Empresa>, IEmpresaRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public EmpresaRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        List<Empresa> IEmpresaRepositorio.BuscarTodos()
        {
            List<Empresa> lista = _contexto.Empresa.Include(e => e.ListaProjetos).ToList();
 
   

            return lista;
        }
    }
}
