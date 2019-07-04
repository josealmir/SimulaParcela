using SimulaParcela.Domain.Core.Interface;
using System.Threading.Tasks;

namespace SimulaParcela.Repositorio.Context
{
    public class UnitOfWork : IUnitOfWork
    {

        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Commit()
                => _dataContext.SaveChanges();

        public Task CommitAsync()
               => _dataContext.SaveChangesAsync();

    }
}
