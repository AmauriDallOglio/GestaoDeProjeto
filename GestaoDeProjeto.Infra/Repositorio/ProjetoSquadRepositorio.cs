using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
using GestaoDeProjeto.Infra.Util;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class ProjetoSquadRepositorio : RepositorioGenerico<ProjetoSquad>, IProjetoSquadRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public ProjetoSquadRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public async Task<List<ProjetoSquad>> BuscarTodosAsync(string descricao)
        {
            var resultado = new List<ProjetoSquad>();
            
            resultado = await _contexto.ProjetoSquad.ToListAsync();
            
            return resultado;
        }
    }
}
