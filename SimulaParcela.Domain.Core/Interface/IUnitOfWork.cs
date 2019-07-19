using System.Threading.Tasks;

namespace SimulaParcela.Domain.Core.Interface
{
    public interface IUnitOfWork
    {      
        void Commit();
        Task CommitAsync();
    }
}
