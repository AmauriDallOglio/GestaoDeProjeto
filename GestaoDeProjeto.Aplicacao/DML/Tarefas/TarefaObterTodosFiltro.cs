using GestaoDeProjeto.Aplicacao.Util;
using GestaoDeProjeto.Dominio.Entidade;
using static GestaoDeProjeto.Dominio.Util.Enums;

namespace GestaoDeProjeto.Aplicacao.DML.Tarefas
{
    public class TarefaObterTodosFiltro : FiltroGenerico<Tarefa>
    {

        public TarefaObterTodosFiltro(TarefaObterTodosRequest filtro)
        {
            // Includes.Add(a => a.Tenant);

            if (filtro.Id_Projeto > 0)
            {
                CriterioWhere = p => p.Id_Projeto == filtro.Id_Projeto;
            }

            if (!string.IsNullOrEmpty(filtro.Descricao))
            {
                CriterioWhere = p => p.Descricao.Contains(filtro.Descricao);
            }

            if (!string.IsNullOrEmpty(filtro.Descricao))
            {
                CriterioWhere = p => p.Objetivo.Contains(filtro.Objetivo);
            }

            if (!string.IsNullOrEmpty(filtro.Descricao))
            {
                CriterioWhere = p => p.Resultado.Contains(filtro.Resultado);
            }

            if (filtro.Situacao >= 0)
            {
                CriterioWhere = p => p.Situacao == (SituacaoProjeto)filtro.Situacao;
            }
            CriterioOrderBy = q => q.OrderByDescending(p => p.Id);
        }
    }
}
