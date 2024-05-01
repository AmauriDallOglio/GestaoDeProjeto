using GestaoDeProjeto.Aplicacao.Util;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Aplicacao.DML.ProjetoSquads
{
    internal class ProjetoSquadObterTodosFiltro : FiltroGenerico<ProjetoSquad>
    {
        public ProjetoSquadObterTodosFiltro(ProjetoSquadObterTodosRequest filtro)
        {
             Includes.Add(a => a.Projeto);
             Includes.Add(a => a.Squad);


            if (filtro.Situacao == (short)Enums.Situacao.Inativo)
            {
                CriterioWhere = p => p.Inativo == (filtro.Situacao == (short)Enums.Situacao.Inativo);
            }
            CriterioOrderBy = q => q.OrderByDescending(p => p.Id);
        }
    }
}
