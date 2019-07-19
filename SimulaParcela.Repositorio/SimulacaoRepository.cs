using SimulaParcela.Dominio.Model;
using SimulaParcela.Dominio.IRepository;

namespace SimulaParcela.Repositorio
{
    public class SimulacaoRepository : Repository<Simulacao> , ISimulacaoRepository
    {
        public SimulacaoRepository(DataContext dataContext)
                : base(dataContext)
        { }
    }
}
