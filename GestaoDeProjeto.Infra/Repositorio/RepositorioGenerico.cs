using GestaoDeProjeto.Dominio.Util;
using GestaoDeProjeto.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly GestaoDeProjetoContexto _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositorioGenerico(GestaoDeProjetoContexto dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> InserirAsync(TEntity entidade, bool finalizar, CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>().AddAsync(entidade);
            _dbContext.MetodoInserir();
            if (finalizar)
            {
                await ComitarAsync();
            }
            return entidade;
        }

        public async Task<TEntity> AlterarAsync(TEntity entidade, bool finalizar, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.MetodoAlterar();
            _dbContext.Set<TEntity>().Update(entidade);
            if (finalizar)
            {
                await ComitarAsync();
            }
            return entidade;
        }

        public async Task<TEntity> DeletarAsync(TEntity entidade, bool finalizar, CancellationToken cancellationToken)
        {
            var reultado = _dbContext.Set<TEntity>().Remove(entidade);
            if (finalizar)
            {
                await ComitarAsync();
            }
            return entidade;
        }



        public async Task<TEntity> ObterPorIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }



        public async Task<int> ComitarAsync()
        {
            int resultado = await _dbContext.SaveChangesAsync();
            return resultado;
        }
 


        public async Task<IEnumerable<TEntity>> ObterTodosAsync(Expression<Func<TEntity, bool>> filter = null,
                                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                string includeProperties = "",
                                                                bool noTracking = false,
                                                                int? take = null,
                                                                int? skip = null,
                                                                CancellationToken cancellationToken = default)

        {
            var consulta = await ObterTodos(filter, orderBy, includeProperties, noTracking, take, skip).ToListAsync(cancellationToken).ConfigureAwait(false);
            return consulta;
        }





        public IQueryable<TEntity> ObterTodos(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool noTracking = false, int? take = null, int? skip = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (noTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);


            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query.Take(take.Value);

            if (orderBy != null)
                query = orderBy(query);


            var sql = query.ToQueryString();

            return query;
        }





        //public Task Rollback()
        //{
        //    _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        //    return Task.CompletedTask;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            //dispose managed resources
        //            _dbContext.Dispose();
        //        }
        //    }
        //    //dispose unmanaged resources
        //    _disposed = true;
        //}

    }
}
