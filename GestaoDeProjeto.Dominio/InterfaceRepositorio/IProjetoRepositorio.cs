using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IProjetoRepositorio : IRepositorioGenerico<Projeto>
    {
        List<Projeto> BuscarTodosPorDescricao(string descricao);

        Task ExcluirEmpresaEProjetos(int idProjeto);
    }
}
