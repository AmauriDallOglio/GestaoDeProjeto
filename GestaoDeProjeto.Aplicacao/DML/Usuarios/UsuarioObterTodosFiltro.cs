using GestaoDeProjeto.Aplicacao.Util;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.Usuarios
{
    public class UsuarioObterTodosFiltro : FiltroGenerico<Usuario>
    {
        public UsuarioObterTodosFiltro(UsuarioObterTodosRequest filtro)
        {
            // Includes.Add(a => a.Tenant);
            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                CriterioWhere = p => p.Nome.Contains(filtro.Nome);
            }

            //if (filtro.Status == StatusInatividade.Inativo)
            //{
            //    CriterioWhere = p => p.Inativo == (filtro.Inativo == StatusInatividade.Inativo);
            //}
            CriterioOrderBy = q => q.OrderByDescending(p => p.Id);
        }
    }
}
