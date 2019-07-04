using SimulaParcela.Dominio.Entidade;

namespace SimulaParcela.Repositorio
{
    public class SimulacaoRepositorio : Repository<Simulacao>
    {
           
        public SimulacaoRepositorio(DataContext dataContext)
                : base(dataContext)
        { }
 
    }
}
