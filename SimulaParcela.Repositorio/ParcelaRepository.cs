using SimulaParcela.Domain.IRepository;
using SimulaParcela.Domain.Model;

namespace SimulaParcela.Repositorio
{
    public class ParcelaRepository : Repository<Parcela> , IParcelaRepository
    {
        public ParcelaRepository(DataContext dataContext)
                : base(dataContext)
        { }
    }
}
