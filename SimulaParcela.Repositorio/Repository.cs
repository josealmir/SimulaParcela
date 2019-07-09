using Microsoft.EntityFrameworkCore;
using SimulaParcela.Domain.Core;
using SimulaParcela.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimulaParcela.Repositorio
{
    public abstract class Repository<T> : IRepositoryRead<T>, IRepositoryWrite<T> where T : Entity
    {

        protected DataContext _dataContext;

        public Repository(DataContext dataContext)
                        => _dataContext = dataContext;

        #region read      

        public IQueryable<T> Query(Expression<Func<T,bool>> filter= null,
                                   Func<IQueryable<T>,IOrderedQueryable<T>> orderBy= null,
                                   params Expression<Func<T,object>>[] includes)
        {
            IQueryable<T> query = _dataContext.Set<T>();
            query = includes.Aggregate(query,(current,include)=>current.Include(include));
            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = orderBy(query);

            return query.AsQueryable();

        }

        public async Task<IList<T>> GetAsync()
        {
            IQueryable<T> query = _dataContext.Set<T>();
            return await query.ToListAsync();
        }
        #endregion

        #region  Write
        public async Task SaveAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            _dataContext.Remove(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            _dataContext.Attach(entity);
        }
        #endregion
    }
}
