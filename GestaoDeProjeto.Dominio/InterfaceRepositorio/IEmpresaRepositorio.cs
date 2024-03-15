using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IEmpresaRepositorio : IRepositorioGenerico<Empresa>
    {
        Task<List<Empresa>> BuscarTodosAsync();
    }
}
