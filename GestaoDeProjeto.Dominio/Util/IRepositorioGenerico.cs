using System.Linq.Expressions;

namespace GestaoDeProjeto.Dominio.Util
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entidade, bool finalizar);
        TEntity Alterar(TEntity entidade, bool finalizar);
        TEntity Deletar(TEntity entidade);
        TEntity ObterPorId(object id);

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


        
        void Comitar();
    }
}