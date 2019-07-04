using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimulaParcela.Domain.Core.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
