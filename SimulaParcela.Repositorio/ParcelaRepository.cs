using SimulaParcela.Dominio.IRepository;
using SimulaParcela.Dominio.Model;

namespace SimulaParcela.Repositorio
{
    public class ParcelaRepository : Repository<Parcela> , IParcelaRepository
    {

        public ParcelaRepository(DataContext dataContext)
                : base(dataContext)
        { }

    }
}
