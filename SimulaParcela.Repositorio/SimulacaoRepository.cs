using SimulaParcela.Domain.Model;
using SimulaParcela.Domain.IRepository;

namespace SimulaParcela.Repositorio
{
    public class SimulacaoRepository : Repository<Simulacao> , ISimulacaoRepository
    {
        public SimulacaoRepository(DataContext dataContext)
                : base(dataContext)
        { }
    }
}
