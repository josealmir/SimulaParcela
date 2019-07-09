using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Dominio.Model;

namespace SimulaParcela.Dominio.IRepository
{
    public interface IParcelaRepository : IRepositoryRead<Parcela>, IRepositoryWrite<Parcela>
    {
        
    }
}
