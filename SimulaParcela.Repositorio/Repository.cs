﻿using Microsoft.EntityFrameworkCore;
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
        protected readonly DbSet<T> DbSet;
        public Repository(DataContext dataContext)    
        {            
            _dataContext = dataContext;
            DbSet = _dataContext.Set<T>();
        }
                     
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
            await DbSet.AddAsync(entity);
        }
        public async Task SaveAsync(IList<T> lista)
        {
            await _dataContext.Set<T>().AddRangeAsync(lista);
            //await DbSet.AddRangeAsync(lista);
        }
        
        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
        }

        #endregion
    }
}
