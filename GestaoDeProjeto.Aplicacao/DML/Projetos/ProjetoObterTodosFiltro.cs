using GestaoDeProjeto.Aplicacao.Util;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Aplicacao.DML.Projetos
{
    public class ProjetoObterTodosFiltro : FiltroGenerico<Projeto>
    {
        public ProjetoObterTodosFiltro(ProjetoObterTodosRequest filtro)
        {
             //Includes.Add(a => a.);
            if (!string.IsNullOrEmpty(filtro.Descricao))
            {
                CriterioWhere = p => p.Descricao.Contains(filtro.Descricao);
            }

            if (filtro.Situacao == (short)Enums.Situacao.Inativo)
            {
                CriterioWhere = p => p.Situacao == (short)Enums.Situacao.Inativo;
            }

            CriterioOrderBy = q => q.OrderByDescending(p => p.Id);
        }
    }
}
