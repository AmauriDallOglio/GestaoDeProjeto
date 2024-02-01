using GestaoDeProjeto.Dominio.Util;
using System.Linq.Expressions;

namespace GestaoDeProjeto.Aplicacao.Util
{
    public abstract class FiltroGenerico<T> : IFiltroGenerico<T> where T : class, IEntity
    {


        public Expression<Func<T, bool>> CriterioWhere { get; set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> CriterioOrderBy { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public List<string> IncludeStrings { get; } = new();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> query)
        {
            return CriterioWhere = CriterioWhere == null ? query : CriterioWhere.And(query);
        }

        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query)
        {
            return CriterioWhere = CriterioWhere == null ? query : CriterioWhere.Or(query);
        }


    }
}
