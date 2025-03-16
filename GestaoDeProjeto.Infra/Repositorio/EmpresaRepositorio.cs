using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
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

        public async Task<List<Empresa>> BuscarTodosAsync()
        {
            List<Empresa> lista = await _contexto.Empresa.ToListAsync();
            //.Include(a => a.ListaProjetos)
            //.Include(a => a.ListaSquads)
            /*  .Include(a => a.ListaUsuarios)*/



            return lista;
        }
    }
}
