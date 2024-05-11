using System.Linq.Expressions;

namespace GestaoDeProjeto.Dominio.Util
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task<TEntity> InserirAsync(TEntity entidade, bool finalizar, CancellationToken cancellationToken);
        Task<TEntity> AlterarAsync(TEntity entidade, bool finalizar, CancellationToken cancellationToken);
        Task<TEntity> DeletarAsync(TEntity entidade, bool finalizar, CancellationToken cancellationToken);
        Task<TEntity> ObterPorIdAsync(object id, CancellationToken cancellationToken);

        // IList<TEntity> ObterTodosPorDescricao(string descricao);

        IQueryable<TEntity> ObterTodos(Expression<Func<TEntity, bool>> filter = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       string includeProperties = "",
                                       bool noTracking = false, 
                                       int? take = null, 
                                       int? skip = null);



        Task<IEnumerable<TEntity>> ObterTodosAsync(Expression<Func<TEntity, bool>> filter = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                   string includeProperties = "",
                                                   bool noTracking = false,
                                                   int? take = null,
                                                   int? skip = null,
                                                   CancellationToken cancellationToken = default);


        
        Task<int> ComitarAsync(CancellationToken cancellationToken);
    }
}