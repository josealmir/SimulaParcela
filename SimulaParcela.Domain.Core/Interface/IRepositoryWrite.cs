﻿
using System.Threading.Tasks;

namespace SimulaParcela.Domain.Core.Interface
{
    public interface IRepositoryWrite<T>  where T : IEntity
    {
        Task SaveAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
