using SimulaParcela.Dominio.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulaParcela.Dominio.IRepositorio
{
    public interface ISimulacaoRepositorio
    {
        Task SalvarAsync(Simulacao entidade);
        Task DeletarAsync(Simulacao entidade);
        Task EditarAsync(Simulacao entidade);
        Task<IList<Simulacao>> GetAsync();
    }
}
