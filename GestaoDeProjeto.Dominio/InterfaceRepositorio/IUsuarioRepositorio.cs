using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.InterfaceRepositorio
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {
        public Task<List<Usuario>> ObterTodosUsuarios();
    }
}