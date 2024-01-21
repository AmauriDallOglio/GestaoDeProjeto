using GestaoDeProjeto.Dominio.InterfaceRepositorio;
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

        public TEntity Inserir(TEntity entidade, bool finalizar)
        {
            _dbContext.Set<TEntity>().Add(entidade);
            //   _dbContext.MetodoInserir();
            if (finalizar)
            {
                Comitar();
            }
            return entidade;
        }

        public TEntity Alterar(TEntity entidade, bool finalizar)
        {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.Set<TEntity>().Update(entidade);
            if (finalizar)
            {
                Comitar();
            }
            return entidade;
        }

        public TEntity Deletar(TEntity entidade)
        {
            var reultado = _dbContext.Set<TEntity>().Remove(entidade);
            Comitar();
            return entidade;
        }



        public TEntity ObterPorId(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }



        public void Comitar()
        {
            var resultadoCommit = _dbContext.SaveChanges();

        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync(Expression<Func<TEntity, bool>> filter = null,
                                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                bool noTracking = false,
                                                                int? take = null,
                                                                int? skip = null,
                                                                CancellationToken cancellationToken = default) =>
                                                                    await ObterTodos(filter, orderBy, noTracking, take, skip).ToListAsync(cancellationToken).ConfigureAwait(false);

        public IQueryable<TEntity> ObterTodos(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool noTracking = false, int? take = null, int? skip = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (noTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            if (orderBy != null)
                query = orderBy(query);

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
