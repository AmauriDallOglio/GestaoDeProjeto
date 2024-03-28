using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IProjetoSquadRepositorio : IRepositorioGenerico<ProjetoSquad>
    {
        Task<List<ProjetoSquad>> BuscarTodosAsync(string descricao);
    }
}
