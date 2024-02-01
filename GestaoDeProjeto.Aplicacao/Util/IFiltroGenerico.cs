using GestaoDeProjeto.Dominio.Util;
using System.Linq.Expressions;

namespace GestaoDeProjeto.Aplicacao.Util
{
    public interface IFiltroGenerico<T> where T : class, IEntity
    {
        Expression<Func<T, bool>> CriterioWhere { get; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> CriterioOrderBy { get; }

        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);
    }
}
