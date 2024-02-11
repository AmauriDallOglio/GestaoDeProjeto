using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IEmpresaRepositorio : IRepositorioGenerico<Empresa>
    {
        List<Empresa> BuscarTodos();
    }
}
