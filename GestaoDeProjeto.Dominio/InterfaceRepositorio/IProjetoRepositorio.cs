using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IProjetoRepositorio : IRepositorioGenerico<Projeto>
    {
        Task<List<Projeto>> BuscarTodosPorDescricaoAsync(string descricao);

        Task ExcluirEmpresaEProjetosAsync(int idProjeto);
    }
}
