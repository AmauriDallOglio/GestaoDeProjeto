using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IProjetoRepositorio : IRepositorioGenerico<Projeto>
    {
        List<Projeto> BuscarTodosPorDescricao(string descricao);

        Task ExcluirEmpresaEProjetos(int idProjeto);
    }
}
