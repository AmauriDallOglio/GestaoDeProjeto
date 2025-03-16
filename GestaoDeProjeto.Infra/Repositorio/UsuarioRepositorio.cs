using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public UsuarioRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public async Task<List<Usuario>> ObterTodosUsuarios()
        {
            var lista = await _contexto.Usuario.ToListAsync();
            return lista;
        }
    }
}
