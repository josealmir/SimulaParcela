
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulaParcela.Domain.Core.Interface
{
    public interface IRepositoryRead<T> where T : IEntity
    {
          Task<IList<T>> GetAsync();
    }
}
