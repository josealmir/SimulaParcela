using Microsoft.EntityFrameworkCore;
using SimulaParcela.Domain.Core;
using SimulaParcela.Domain.Core.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimulaParcela.Repositorio
{
    public abstract class Repository<T> : IRepositoryRead<T>, IRepositoryWrite<T> where T : Entity
    {

        private DataContext _dataContext;

        public Repository(DataContext dataContext)
                        => _dataContext = dataContext;

        public async Task<IList<T>> GetAlAsync()
        {
            IQueryable<T> query = _dataContext.Set<T>();
            return await query.ToListAsync();
        }

        public async Task SaveAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
