using GestaoDeProjeto.Aplicacao.Util;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Aplicacao.DML.Empresas
{
    public class EmpresaObterTodosFiltro : FiltroGenerico<Empresa>
    {
        public EmpresaObterTodosFiltro(EmpresaObterTodosRequest filtro)
        {
           
            if (!string.IsNullOrEmpty(filtro.NomeFantasia))
            {
                CriterioWhere = p => p.NomeFantasia.Contains(filtro.NomeFantasia);
            }

            if (filtro.Situacao == true)
            {
                CriterioWhere = p => p.Inativo == true;
            }

            CriterioOrderBy = q => q.OrderByDescending(p => p.NomeFantasia);
        }
       
    }
}
