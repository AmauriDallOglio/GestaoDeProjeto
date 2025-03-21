﻿using GestaoDeProjeto.Aplicacao.Util;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.Squads
{
    public class SquadObterTodosFiltro : FiltroGenerico<Squad>
    {
        public SquadObterTodosFiltro(SquadObterTodosRequest filtro)
        {
            // Includes.Add(a => a.Tenant);
            if (!string.IsNullOrEmpty(filtro.Descricao))
            {
                CriterioWhere = p => p.Descricao.Contains(filtro.Descricao);
            }

            //if (filtro.Status == StatusInatividade.Inativo)
            //{
            //    CriterioWhere = p => p.Inativo == (filtro.Inativo == StatusInatividade.Inativo);
            //}
            CriterioOrderBy = q => q.OrderByDescending(p => p.Id);
        }
    }
}
