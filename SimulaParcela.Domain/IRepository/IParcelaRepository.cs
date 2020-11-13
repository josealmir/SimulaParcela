using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Domain.Model;

namespace SimulaParcela.Domain.IRepository
{
    public interface IParcelaRepository : IRepositoryRead<Parcela>, IRepositoryWrite<Parcela>
    {
        
    }
}
